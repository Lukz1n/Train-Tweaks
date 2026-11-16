using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarOverwatch2 : GamePriorityOperation
{
    public PriorizarOverwatch2() : base("overwatch2", new[] { "Overwatch.exe" }, 3) { }
}
