using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class LimparFilaImpressao : PowerShellOperation
{
    public LimparFilaImpressao() : base("Apaga trabalhos pendentes de impressão e reinicia o Spooler.", true) { }

    protected override string Script => """
$spool=Join-Path $env:windir 'System32\spool\PRINTERS'
Stop-Service Spooler -Force -ErrorAction SilentlyContinue
Get-ChildItem -LiteralPath $spool -Include *.SHD,*.SPL -File -ErrorAction SilentlyContinue | Remove-Item -Force -ErrorAction SilentlyContinue
Start-Service Spooler
""";
}
