using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarXbox : PowerShellOperation
{
    public DesativarXbox() : base("Remove pacotes Xbox da conta e desativa serviços relacionados; pode afetar jogos e recursos Xbox.", true) { }

    protected override string Script => """
$ErrorActionPreference='Continue'
Get-AppxPackage '*Xbox*' | Remove-AppxPackage -ErrorAction Continue
Get-AppxProvisionedPackage -Online | Where-Object DisplayName -Like '*Xbox*' | Remove-AppxProvisionedPackage -Online -ErrorAction Continue
foreach ($n in @('XblAuthManager','XblGameSave','XboxNetApiSvc','XboxGipSvc')) { Stop-Service $n -Force -ErrorAction SilentlyContinue; Set-Service $n -StartupType Disabled -ErrorAction SilentlyContinue }
""";
}
