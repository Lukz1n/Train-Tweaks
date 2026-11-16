using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarHibernacao : PowerShellOperation
{
    public DesativarHibernacao() : base("Desativa hibernação e remove o arquivo de hibernação do sistema.", true) { }

    protected override string Script => """
& powercfg.exe -h off
""";
}
