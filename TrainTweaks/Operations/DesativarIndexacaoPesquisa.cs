using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarIndexacaoPesquisa : PowerShellOperation
{
    public DesativarIndexacaoPesquisa() : base("Desativa o serviço de indexação; buscas de arquivos podem ficar mais lentas.", true) { }

    protected override string Script => """
Stop-Service WSearch -Force -ErrorAction SilentlyContinue; Set-Service WSearch -StartupType Disabled
""";
}
