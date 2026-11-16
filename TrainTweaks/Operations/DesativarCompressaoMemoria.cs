using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarCompressaoMemoria : PowerShellOperation
{
    public DesativarCompressaoMemoria() : base("Desativa a compressão de memória do Windows.", true) { }

    protected override string Script => """
Disable-MMAgent -MemoryCompression
""";
}
