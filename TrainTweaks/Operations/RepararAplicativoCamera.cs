using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class RepararAplicativoCamera : PowerShellOperation
{
    public RepararAplicativoCamera() : base("Tenta registrar novamente o aplicativo Câmera do Windows.", true) { }

    protected override string Script => """
Get-AppxPackage -AllUsers '*WindowsCamera*' -ErrorAction SilentlyContinue | ForEach-Object {$m=Join-Path $_.InstallLocation 'AppXManifest.xml'; if(Test-Path $m){Add-AppxPackage -DisableDevelopmentMode -Register $m -ErrorAction SilentlyContinue}}
""";
}
