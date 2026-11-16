using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarAmericanTruckSimulator : GamePriorityOperation
{
    public PriorizarAmericanTruckSimulator() : base("americantrucksimulator", new[] { "amtrucks.exe" }, 3) { }
}
