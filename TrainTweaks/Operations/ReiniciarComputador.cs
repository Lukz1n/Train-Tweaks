using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class ReiniciarComputador : PowerShellOperation
{
    public ReiniciarComputador() : base("Reinicia o computador imediatamente. Salve os arquivos antes de executar.", true) { }

    protected override string Script => """
& shutdown.exe /r /t 0
""";
}
