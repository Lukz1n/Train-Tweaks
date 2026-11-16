using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixCopiarColar : PowerShellOperation
{
    public FixCopiarColar() : base("Limpa a área de transferência atual e abre suas configurações.", false) { }

    protected override string Script => """
Set-Clipboard -Value ''; Start-Process 'ms-settings:clipboard'
""";
}
