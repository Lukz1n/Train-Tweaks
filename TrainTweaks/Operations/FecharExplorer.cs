using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FecharExplorer : PowerShellOperation
{
    public FecharExplorer() : base("Encerra o Explorer; a área de trabalho e barra de tarefas desaparecem até ele ser iniciado novamente.", false) { }

    protected override string Script => """
Get-Process explorer -ErrorAction SilentlyContinue | Stop-Process -Force
""";
}
