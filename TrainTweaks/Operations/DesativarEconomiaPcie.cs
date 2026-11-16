using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarEconomiaPcie : PowerShellOperation
{
    public DesativarEconomiaPcie() : base("Desativa economia de energia Link State do PCI Express.", true) { }

    protected override string Script => """
& powercfg.exe /setacvalueindex SCHEME_CURRENT SUB_PCIEXPRESS ASPM 0
& powercfg.exe /setdcvalueindex SCHEME_CURRENT SUB_PCIEXPRESS ASPM 0
& powercfg.exe /setactive SCHEME_CURRENT
""";
}
