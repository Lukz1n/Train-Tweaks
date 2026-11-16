using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarCounterStrike2 : GamePriorityOperation
{
    public PriorizarCounterStrike2() : base("cs2", new[] { "cs2.exe" }, 3) { }
}
