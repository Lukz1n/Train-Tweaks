using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class LiberarMemoriaRam : PowerShellOperation
{
    public LiberarMemoriaRam() : base("Executa EmptyStandbyList.exe nos três conjuntos de memória usados pelo BAT.", true) { }

    protected override string Script => """
$exe = Join-Path $PWD.Path 'EmptyStandbyList.exe'
if (-not (Test-Path -LiteralPath $exe)) { throw 'EmptyStandbyList.exe não foi encontrado ao lado do assembly.' }
foreach ($arg in @('workingsets','modifiedpagelist','standbylist')) { Start-Process -FilePath $exe -ArgumentList $arg -Wait -NoNewWindow }
""";
}
