using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixXboxApp : PowerShellOperation
{
    public FixXboxApp() : base("Tenta iniciar serviços e registrar novamente os pacotes Xbox presentes.", true) { }

    protected override string Script => """
foreach($n in @('XboxGipSvc','XblAuthManager','XblGameSave','XboxNetApiSvc')){Start-Service $n -ErrorAction SilentlyContinue}; Get-AppxPackage '*Xbox*' | ForEach-Object {$m=Join-Path $_.InstallLocation 'AppxManifest.xml'; if(Test-Path $m){Add-AppxPackage -DisableDevelopmentMode -Register $m -ErrorAction SilentlyContinue}}
""";
}
