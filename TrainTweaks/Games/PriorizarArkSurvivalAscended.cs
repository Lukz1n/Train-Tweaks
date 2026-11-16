using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarArkSurvivalAscended : GamePriorityOperation
{
    public PriorizarArkSurvivalAscended() : base("arksurvivalascended", new[] { "ArkAscended.exe" }, 3) { }
}
