using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AtivarModoJogo : PowerShellOperation
{
    public AtivarModoJogo() : base("Ativa Game Mode para a conta atual.", false) { }

    protected override string Script => """
$k='HKCU:\Software\Microsoft\GameBar'; New-Item $k -Force|Out-Null; Set-ItemProperty $k AutoGameModeEnabled 1 -Type DWord; Set-ItemProperty $k AllowAutoGameMode 1 -Type DWord
""";
}
