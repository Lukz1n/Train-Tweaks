using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AbrirDnsJumper : PowerShellOperation
{
    public AbrirDnsJumper() : base("Abre o utilitário DnsJumper se estiver junto ao assembly.", false) { }

    protected override string Script => """
$exe = Join-Path $PWD.Path 'DnsJumper.exe'
if (-not (Test-Path -LiteralPath $exe)) { throw 'DnsJumper.exe não foi encontrado ao lado do assembly.' }
Start-Process -FilePath $exe
""";
}
