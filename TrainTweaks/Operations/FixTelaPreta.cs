using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixTelaPreta : PowerShellOperation
{
    public FixTelaPreta() : base("Reinicia o Explorer e verifica arquivos do Windows.", true) { }

    protected override string Script => """
Get-Process explorer -ErrorAction SilentlyContinue|Stop-Process -Force; Start-Sleep -Seconds 2; Start-Process explorer.exe; & sfc.exe /scannow
""";
}
