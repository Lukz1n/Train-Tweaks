using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFarmingSimulator22 : GamePriorityOperation
{
    public PriorizarFarmingSimulator22() : base("fs22", new[] { "FarmingSimulator2022Game.exe" }, 3) { }
}
