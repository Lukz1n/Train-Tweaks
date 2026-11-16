using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarArenaBreakout : GamePriorityOperation
{
    public PriorizarArenaBreakout() : base("arenabreakout", new[] { "UAGame.exe" }, 3) { }
}
