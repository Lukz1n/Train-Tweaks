using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace TrainTweaks.ConsoleApp;

internal sealed record TaskCommandResult(bool Succeeded, string Output);
internal sealed record CleanerTaskStatus(bool Exists, string Output);

internal sealed class CleanerTaskScheduler
{
    public const string TaskName = "Train Tweaks Auto Cleaner";

    public async Task<TaskCommandResult> InstallWeeklyAsync(DayOfWeek day, TimeOnly time, CancellationToken cancellationToken = default)
    {
        if (!OperatingSystem.IsWindows())
            return new TaskCommandResult(false, "O Agendador do Windows não está disponível neste sistema.");

        var startBoundary = NextOccurrence(day, time);
        var currentUser = WindowsIdentity.GetCurrent().User?.Value;
        if (string.IsNullOrWhiteSpace(currentUser))
            return new TaskCommandResult(false, "Não foi possível identificar a conta atual do Windows.");

        var executable = Environment.ProcessPath;
        if (string.IsNullOrWhiteSpace(executable))
            return new TaskCommandResult(false, "Não foi possível localizar o executável atual.");

        var arguments = "--cleaner-run";
        if (string.Equals(Path.GetFileNameWithoutExtension(executable), "dotnet", StringComparison.OrdinalIgnoreCase))
        {
            var assemblyPath = Assembly.GetEntryAssembly()?.Location;
            if (string.IsNullOrWhiteSpace(assemblyPath))
                return new TaskCommandResult(false, "Não foi possível localizar o assembly do programa.");
            arguments = $"{Quote(assemblyPath)} --cleaner-run";
        }

        var xml = BuildTaskXml(currentUser, startBoundary, executable, arguments, AppContext.BaseDirectory);
        var xmlPath = Path.Combine(Path.GetTempPath(), $"TrainTweaks-{Guid.NewGuid():N}.xml");
        try
        {
            await File.WriteAllTextAsync(xmlPath, xml, Encoding.Unicode, cancellationToken);
            return await RunSchtasksAsync(new[] { "/Create", "/TN", TaskName, "/XML", xmlPath, "/F" }, cancellationToken);
        }
        catch (Exception exception)
        {
            return new TaskCommandResult(false, exception.Message);
        }
        finally
        {
            try { File.Delete(xmlPath); } catch { }
        }
    }

    public async Task<CleanerTaskStatus> GetStatusAsync(CancellationToken cancellationToken = default)
    {
        if (!OperatingSystem.IsWindows())
            return new CleanerTaskStatus(false, "O Agendador do Windows não está disponível neste sistema.");
        var result = await RunSchtasksAsync(new[] { "/Query", "/TN", TaskName, "/FO", "LIST", "/V" }, cancellationToken);
        return new CleanerTaskStatus(result.Succeeded, result.Output);
    }

    public async Task<TaskCommandResult> RemoveAsync(CancellationToken cancellationToken = default)
    {
        if (!OperatingSystem.IsWindows())
            return new TaskCommandResult(false, "O Agendador do Windows não está disponível neste sistema.");
        var status = await GetStatusAsync(cancellationToken);
        if (!status.Exists)
            return new TaskCommandResult(true, "A tarefa semanal não está instalada.");
        return await RunSchtasksAsync(new[] { "/Delete", "/TN", TaskName, "/F" }, cancellationToken);
    }

    private static DateTime NextOccurrence(DayOfWeek day, TimeOnly time)
    {
        var now = DateTime.Now;
        var offset = ((int)day - (int)now.DayOfWeek + 7) % 7;
        var next = now.Date.AddDays(offset).Add(time.ToTimeSpan());
        return next <= now ? next.AddDays(7) : next;
    }

    private static string BuildTaskXml(string userSid, DateTime start, string executable, string arguments, string workingDirectory)
    {
        var dayTag = start.DayOfWeek.ToString();
        return $"""
<?xml version="1.0" encoding="UTF-16"?>
<Task version="1.4" xmlns="http://schemas.microsoft.com/windows/2004/02/mit/task">
  <RegistrationInfo>
    <Author>Train Tweaks</Author>
    <Description>Limpa arquivos temporários antigos uma vez por semana.</Description>
  </RegistrationInfo>
  <Triggers>
    <CalendarTrigger>
      <StartBoundary>{start:yyyy-MM-dd'T'HH:mm:ss}</StartBoundary>
      <Enabled>true</Enabled>
      <ScheduleByWeek>
        <DaysOfWeek><{dayTag} /></DaysOfWeek>
        <WeeksInterval>1</WeeksInterval>
      </ScheduleByWeek>
    </CalendarTrigger>
  </Triggers>
  <Principals>
    <Principal id="CurrentUser">
      <UserId>{EscapeXml(userSid)}</UserId>
      <LogonType>InteractiveToken</LogonType>
      <RunLevel>LeastPrivilege</RunLevel>
    </Principal>
  </Principals>
  <Settings>
    <MultipleInstancesPolicy>IgnoreNew</MultipleInstancesPolicy>
    <DisallowStartIfOnBatteries>false</DisallowStartIfOnBatteries>
    <StopIfGoingOnBatteries>false</StopIfGoingOnBatteries>
    <AllowHardTerminate>true</AllowHardTerminate>
    <StartWhenAvailable>true</StartWhenAvailable>
    <RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>
    <AllowStartOnDemand>true</AllowStartOnDemand>
    <Enabled>true</Enabled>
    <Hidden>true</Hidden>
    <RunOnlyIfIdle>false</RunOnlyIfIdle>
    <WakeToRun>false</WakeToRun>
    <ExecutionTimeLimit>PT2H</ExecutionTimeLimit>
    <Priority>7</Priority>
  </Settings>
  <Actions Context="CurrentUser">
    <Exec>
      <Command>{EscapeXml(executable)}</Command>
      <Arguments>{EscapeXml(arguments)}</Arguments>
      <WorkingDirectory>{EscapeXml(workingDirectory)}</WorkingDirectory>
    </Exec>
  </Actions>
</Task>
""";
    }

    private static string EscapeXml(string value)
    {
        return value.Replace("&", "&amp;", StringComparison.Ordinal)
            .Replace("<", "&lt;", StringComparison.Ordinal)
            .Replace(">", "&gt;", StringComparison.Ordinal)
            .Replace("\"", "&quot;", StringComparison.Ordinal)
            .Replace("'", "&apos;", StringComparison.Ordinal);
    }

    private static string Quote(string value)
    {
        return "\"" + value.Replace("\"", "\\\"", StringComparison.Ordinal) + "\"";
    }

    private static async Task<TaskCommandResult> RunSchtasksAsync(IEnumerable<string> arguments, CancellationToken cancellationToken)
    {
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = "schtasks.exe",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
        foreach (var argument in arguments)
            process.StartInfo.ArgumentList.Add(argument);

        process.Start();
        var outputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var errorTask = process.StandardError.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);
        var output = await outputTask;
        var error = await errorTask;
        var combined = string.Join(Environment.NewLine, new[] { output.Trim(), error.Trim() }.Where(text => text.Length > 0));
        return new TaskCommandResult(process.ExitCode == 0, combined);
    }
}
