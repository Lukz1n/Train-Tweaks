using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AbrirAutoruns : PowerShellOperation
{
    public AbrirAutoruns() : base("Abre Autoruns.exe se estiver junto ao assembly.", false) { }

    protected override string Script => """
$exe = Join-Path $PWD.Path 'Autoruns.exe'
if (-not (Test-Path -LiteralPath $exe)) { throw 'Autoruns.exe não foi encontrado ao lado do assembly.' }
Start-Process -FilePath $exe
""";
}
