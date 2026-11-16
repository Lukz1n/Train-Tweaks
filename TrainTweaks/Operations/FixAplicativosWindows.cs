using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixAplicativosWindows : PowerShellOperation
{
    public FixAplicativosWindows() : base("Repara imagem/arquivos e tenta registrar novamente pacotes Appx instalados.", true) { }

    protected override string Script => """
& DISM.exe /Online /Cleanup-Image /RestoreHealth; & sfc.exe /scannow; Get-AppxPackage | Where-Object {$_.InstallLocation -and (Test-Path (Join-Path $_.InstallLocation 'AppxManifest.xml'))} | ForEach-Object {Add-AppxPackage -DisableDevelopmentMode -Register (Join-Path $_.InstallLocation 'AppxManifest.xml') -ErrorAction SilentlyContinue}
""";
}
