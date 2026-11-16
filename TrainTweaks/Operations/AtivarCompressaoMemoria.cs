using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AtivarCompressaoMemoria : PowerShellOperation
{
    public AtivarCompressaoMemoria() : base("Ativa novamente a compressão de memória do Windows.", true) { }

    protected override string Script => """
Enable-MMAgent -MemoryCompression
""";
}
