using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarCompatibilidadeForcada : PowerShellOperation
{
    public DesativarCompatibilidadeForcada() : base("Desativa o assistente e as políticas de compatibilidade.", true) { }

    protected override string Script => """
Stop-Service PcaSvc -Force -ErrorAction SilentlyContinue; Set-Service PcaSvc -StartupType Disabled
$k='HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppCompat'; New-Item $k -Force|Out-Null; Set-ItemProperty $k DisablePCA 1 -Type DWord; Set-ItemProperty $k DisableEngine 1 -Type DWord; Set-ItemProperty $k DisableInventory 1 -Type DWord
""";
}
