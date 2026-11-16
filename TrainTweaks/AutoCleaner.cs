using System.Text;

namespace TrainTweaks.ConsoleApp;

internal sealed record CleanResult(int FilesDeleted, int DirectoriesDeleted, int Errors, string LogPath);

internal static class AutoCleaner
{
    private static readonly TimeSpan MinimumAge = TimeSpan.FromDays(7);

    public static Task<CleanResult> RunAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Run(cancellationToken), cancellationToken);
    }

    private static CleanResult Run(CancellationToken cancellationToken)
    {
        var logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Train Tweaks");
        Directory.CreateDirectory(logDirectory);
        var logPath = Path.Combine(logDirectory, "AutoCleaner.log");
        var cutoff = DateTime.UtcNow.Subtract(MinimumAge);
        var counters = new Counters();
        var windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        var roots = new[]
        {
            Path.GetTempPath(),
            string.IsNullOrWhiteSpace(windows) ? string.Empty : Path.Combine(windows, "Temp")
        }.Where(path => !string.IsNullOrWhiteSpace(path)).Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var root in roots)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!Directory.Exists(root))
                continue;
            CleanDirectory(root, cutoff, counters, cancellationToken);
        }

        var finished = new CleanResult(counters.FilesDeleted, counters.DirectoriesDeleted, counters.Errors, logPath);
        var entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | removidos: {finished.FilesDeleted} arquivos, {finished.DirectoriesDeleted} pastas | ignorados: {finished.Errors}{Environment.NewLine}";
        File.AppendAllText(logPath, entry, Encoding.UTF8);
        return finished;
    }

    private static void CleanDirectory(string path, DateTime cutoff, Counters counters, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string[] directories;
        string[] files;
        try
        {
            directories = Directory.GetDirectories(path);
            files = Directory.GetFiles(path);
        }
        catch
        {
            counters.Errors++;
            return;
        }

        foreach (var file in files)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var info = new FileInfo(file);
                if (info.LastWriteTimeUtc >= cutoff || (info.Attributes & FileAttributes.ReparsePoint) != 0)
                    continue;
                if ((info.Attributes & FileAttributes.ReadOnly) != 0)
                    info.Attributes &= ~FileAttributes.ReadOnly;
                info.Delete();
                counters.FilesDeleted++;
            }
            catch
            {
                counters.Errors++;
            }
        }

        foreach (var directory in directories)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var attributes = File.GetAttributes(directory);
                if ((attributes & FileAttributes.ReparsePoint) != 0)
                    continue;
                CleanDirectory(directory, cutoff, counters, cancellationToken);
                if (Directory.GetLastWriteTimeUtc(directory) < cutoff && !Directory.EnumerateFileSystemEntries(directory).Any())
                {
                    Directory.Delete(directory, false);
                    counters.DirectoriesDeleted++;
                }
            }
            catch
            {
                counters.Errors++;
            }
        }
    }

    private sealed class Counters
    {
        public int FilesDeleted { get; set; }
        public int DirectoriesDeleted { get; set; }
        public int Errors { get; set; }
    }
}
