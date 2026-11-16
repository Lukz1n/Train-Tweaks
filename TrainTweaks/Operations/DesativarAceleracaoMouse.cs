using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarAceleracaoMouse : PowerShellOperation
{
    public DesativarAceleracaoMouse() : base("Desativa aceleração do mouse na conta atual.", false) { }

    protected override string Script => """
$k='HKCU:\Control Panel\Mouse'; Set-ItemProperty $k MouseSpeed '0' -Type String; Set-ItemProperty $k MouseThreshold1 '0' -Type String; Set-ItemProperty $k MouseThreshold2 '0' -Type String
""";
}
