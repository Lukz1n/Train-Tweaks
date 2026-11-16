using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixArquivosCorrompidos : PowerShellOperation
{
    public FixArquivosCorrompidos() : base("Executa SFC e DISM para reparar arquivos do Windows.", true) { }

    protected override string Script => """
& sfc.exe /scannow; & DISM.exe /Online /Cleanup-Image /RestoreHealth
""";
}
