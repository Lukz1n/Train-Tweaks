using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarEuroTruckSimulator : GamePriorityOperation
{
    public PriorizarEuroTruckSimulator() : base("ets", new[] { "eurotrucks.exe", "eurotrucks2.exe" }, 3) { }
}
