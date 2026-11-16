using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarFullscreenOptimizations : PowerShellOperation
{
    public DesativarFullscreenOptimizations() : base("Aplica os valores de comportamento fullscreen do BAT.", false) { }

    protected override string Script => """
$k='HKCU:\System\GameConfigStore'; New-Item $k -Force|Out-Null; Set-ItemProperty $k GameDVR_FSEBehaviorMode 2 -Type DWord; Set-ItemProperty $k GameDVR_HonorUserFSEBehaviorMode 1 -Type DWord
""";
}
