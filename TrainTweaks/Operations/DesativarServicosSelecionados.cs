using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarServicosSelecionados : PowerShellOperation
{
    public DesativarServicosSelecionados() : base("Desativa os serviços listados no BAT. Isso também desliga o serviço de impressão e biometria.", true) { }

    protected override string Script => """
foreach ($name in @('WerSvc','DiagTrack','dmwappushservice','WbioSrvc','Spooler')) { try { Stop-Service -Name $name -Force -ErrorAction SilentlyContinue; Set-Service -Name $name -StartupType Disabled -ErrorAction Stop } catch { Write-Output "$name: $($_.Exception.Message)" } }
""";
}
