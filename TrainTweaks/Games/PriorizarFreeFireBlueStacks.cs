using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFreeFireBlueStacks : GamePriorityOperation
{
    public PriorizarFreeFireBlueStacks() : base("freefire", new[] { "HD-Player.exe" }, 3) { }
}
