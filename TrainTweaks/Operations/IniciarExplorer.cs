using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class IniciarExplorer : PowerShellOperation
{
    public IniciarExplorer() : base("Inicia o Explorer do Windows.", false) { }

    protected override string Script => """
Start-Process explorer.exe
""";
}
