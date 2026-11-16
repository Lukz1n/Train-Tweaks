using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class VerificarRepararArquivosWindows : PowerShellOperation
{
    public VerificarRepararArquivosWindows() : base("Executa DISM e SFC para verificar e reparar arquivos do Windows.", true) { }

    protected override string Script => """
& DISM.exe /Online /Cleanup-Image /RestoreHealth; if ($LASTEXITCODE -ne 0) { throw 'DISM terminou com erro.' }; & sfc.exe /scannow
""";
}
