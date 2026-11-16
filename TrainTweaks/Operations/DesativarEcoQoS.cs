using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarEcoQoS : PowerShellOperation
{
    public DesativarEcoQoS() : base("Aplica o mesmo controle global de Power Throttling; não garante desativar EcoQoS de cada processo.", true) { }

    protected override string Script => """
$k='HKLM:\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling'; New-Item $k -Force|Out-Null; Set-ItemProperty $k PowerThrottlingOff 1 -Type DWord
""";
}
