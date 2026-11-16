using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixErroDisco : PowerShellOperation
{
    public FixErroDisco() : base("Executa CHKDSK com reparo na unidade C:. Pode levar bastante tempo e solicitar reinicialização.", true) { }

    protected override string Script => """
& chkdsk.exe C: /f /r
""";
}
