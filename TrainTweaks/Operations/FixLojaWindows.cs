using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixLojaWindows : PowerShellOperation
{
    public FixLojaWindows() : base("Reativa BITS e tenta registrar novamente pacotes Appx.", true) { }

    protected override string Script => """
Set-Service BITS -StartupType Automatic; Start-Service BITS; Get-AppxPackage -AllUsers | ForEach-Object {$m=Join-Path $_.InstallLocation 'AppxManifest.xml'; if($_.InstallLocation -and (Test-Path $m)){Add-AppxPackage -DisableDevelopmentMode -Register $m -ErrorAction SilentlyContinue}}
""";
}
