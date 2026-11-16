using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarWarface : GamePriorityOperation
{
    public PriorizarWarface() : base("warface", new[] { "Game.exe" }, 3) { }
}
