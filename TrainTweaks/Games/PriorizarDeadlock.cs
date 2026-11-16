using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDeadlock : GamePriorityOperation
{
    public PriorizarDeadlock() : base("deadlock", new[] { "deadlock.exe" }, 3) { }
}
