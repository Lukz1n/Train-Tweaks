using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarApexLegends : GamePriorityOperation
{
    public PriorizarApexLegends() : base("apex", new[] { "r5apex.exe" }, 3) { }
}
