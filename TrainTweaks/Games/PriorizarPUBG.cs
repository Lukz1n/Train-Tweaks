using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPUBG : GamePriorityOperation
{
    public PriorizarPUBG() : base("pubg", new[] { "TslGame.exe" }, 3) { }
}
