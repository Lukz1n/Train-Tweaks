using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarTelemetria : PowerShellOperation
{
    public DesativarTelemetria() : base("Aplica políticas de privacidade do BAT; a política do Windows Update pode limitar fontes online.", true) { }

    protected override string Script => """
$items=@(
@('HKLM:\SOFTWARE\Policies\Microsoft\Windows\DataCollection','AllowTelemetry',0),
@('HKLM:\SOFTWARE\Policies\Microsoft\Windows\System','AllowAppDataCollection',0),
@('HKLM:\SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo','DisableWindowsAdvertising',1),
@('HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent','DisableMicrosoftConsumerExperience',1),
@('HKLM:\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate','DoNotConnectToWindowsUpdateInternetLocations',1))
foreach($i in $items){New-Item $i[0] -Force|Out-Null; Set-ItemProperty $i[0] $i[1] $i[2] -Type DWord}
""";
}
