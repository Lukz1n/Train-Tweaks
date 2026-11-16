using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFarmingSimulator25 : GamePriorityOperation
{
    public PriorizarFarmingSimulator25() : base("fs25", new[] { "FarmingSimulator2025Game.exe" }, 3) { }
}
