using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarPowerThrottling : PowerShellOperation
{
    public DesativarPowerThrottling() : base("Desativa Power Throttling globalmente; pode aumentar consumo e temperatura.", true) { }

    protected override string Script => """
$k='HKLM:\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling'; New-Item $k -Force|Out-Null; Set-ItemProperty $k PowerThrottlingOff 1 -Type DWord
""";
}
