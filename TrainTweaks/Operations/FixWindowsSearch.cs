using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixWindowsSearch : PowerShellOperation
{
    public FixWindowsSearch() : base("Reativa Windows Search e abre opções de indexação.", true) { }

    protected override string Script => """
Set-Service WSearch -StartupType Automatic; Restart-Service WSearch -Force -ErrorAction SilentlyContinue; Start-Process 'control.exe' -ArgumentList 'srchadmin.dll'
""";
}
