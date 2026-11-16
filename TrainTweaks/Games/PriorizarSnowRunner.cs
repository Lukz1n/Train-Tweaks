using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSnowRunner : GamePriorityOperation
{
    public PriorizarSnowRunner() : base("snowrunner", new[] { "SnowRunner.exe" }, 3) { }
}
