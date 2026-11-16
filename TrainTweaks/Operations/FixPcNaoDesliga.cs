using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixPcNaoDesliga : PowerShellOperation
{
    public FixPcNaoDesliga() : base("Ativa hibernação novamente. A rotina não força desligamento do computador.", true) { }

    protected override string Script => """
& powercfg.exe -h on
""";
}
