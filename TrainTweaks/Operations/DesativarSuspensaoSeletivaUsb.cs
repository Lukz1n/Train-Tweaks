using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarSuspensaoSeletivaUsb : PowerShellOperation
{
    public DesativarSuspensaoSeletivaUsb() : base("Desativa suspensão seletiva de USB em alimentação AC e bateria; aumenta consumo em notebooks.", true) { }

    protected override string Script => """
& powercfg.exe /setacvalueindex SCHEME_CURRENT SUB_USB USBSELECTIVE 0
& powercfg.exe /setdcvalueindex SCHEME_CURRENT SUB_USB USBSELECTIVE 0
& powercfg.exe /setactive SCHEME_CURRENT
""";
}
