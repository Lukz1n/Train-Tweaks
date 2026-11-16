using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AbrirArquivoDebloater : PowerShellOperation
{
    public AbrirArquivoDebloater() : base("Abre debloater.bat ao lado do assembly, se existir.", false) { }

    protected override string Script => """
$path=Join-Path $PWD.Path 'debloater.bat'; if(-not(Test-Path $path)){throw 'debloater.bat não foi encontrado ao lado do assembly.'}; Start-Process -FilePath $path
""";
}
