using System.Diagnostics;
using System.Security.Principal;
using System.Text;

namespace TrainTweaks.Core;

public sealed record OperationResult(string Name, int ExitCode, string StandardOutput, string StandardError)
{
    public bool Succeeded => ExitCode == 0;
}

public abstract class WindowsOperation
{
    protected WindowsOperation(string name, bool requiresAdministrator)
    {
        Name = name;
        RequiresAdministrator = requiresAdministrator;
    }

    public string Name { get; }
    public bool RequiresAdministrator { get; }

    public Task<OperationResult> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        if (!OperatingSystem.IsWindows())
            throw new PlatformNotSupportedException("Esta operação só pode ser executada no Windows.");
        if (RequiresAdministrator && !IsAdministrator())
            throw new UnauthorizedAccessException("Execute o aplicativo hospedeiro como administrador para esta operação.");
        return ExecuteCoreAsync(cancellationToken);
    }

    protected abstract Task<OperationResult> ExecuteCoreAsync(CancellationToken cancellationToken);

    private static bool IsAdministrator()
    {
        using var identity = WindowsIdentity.GetCurrent();
        return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
    }
}

public abstract class PowerShellOperation : WindowsOperation
{
    protected PowerShellOperation(string name, bool requiresAdministrator) : base(name, requiresAdministrator) { }
    protected abstract string Script { get; }

    protected override async Task<OperationResult> ExecuteCoreAsync(CancellationToken cancellationToken)
    {
        var prelude = """
$ErrorActionPreference = 'Stop'
function Set-ItemProperty {
    param([string]$Path, [string]$Name, $Value, [string]$Type)
    if ($Type) {
        if (-not (Test-Path -LiteralPath $Path)) { New-Item -Path $Path -Force | Out-Null }
        New-ItemProperty -LiteralPath $Path -Name $Name -Value $Value -PropertyType $Type -Force | Out-Null
    } else {
        Microsoft.PowerShell.Management\Set-ItemProperty -LiteralPath $Path -Name $Name -Value $Value | Out-Null
    }
}
""";
        var encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(prelude + Script));
        var start = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            WorkingDirectory = AppContext.BaseDirectory,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8
        };
        start.ArgumentList.Add("-NoProfile");
        start.ArgumentList.Add("-NonInteractive");
        start.ArgumentList.Add("-ExecutionPolicy");
        start.ArgumentList.Add("RemoteSigned");
        start.ArgumentList.Add("-EncodedCommand");
        start.ArgumentList.Add(encoded);

        using var process = new Process { StartInfo = start };
        process.Start();
        var stdout = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var stderr = process.StandardError.ReadToEndAsync(cancellationToken);
        try
        {
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            try { process.Kill(entireProcessTree: true); } catch { }
            throw;
        }
        return new OperationResult(Name, process.ExitCode, await stdout.ConfigureAwait(false), await stderr.ConfigureAwait(false));
    }
}

public abstract class GamePriorityOperation : PowerShellOperation
{
    private readonly string[] _executables;
    private readonly int _priorityClass;

    protected GamePriorityOperation(string gameName, string[] executables, int priorityClass)
        : base($"Prioridade de {gameName}", true)
    {
        _executables = executables;
        _priorityClass = priorityClass;
    }

    protected override string Script
    {
        get
        {
            var exeList = string.Join(",", _executables.Select(x => "'" + x.Replace("'", "''") + "'"));
            return $"$names=@({exeList}); foreach($exe in $names){{$k='HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\'+$exe+'\\PerfOptions'; New-Item $k -Force|Out-Null; Set-ItemProperty $k CpuPriorityClass {_priorityClass} -Type DWord}}";
        }
    }
}
