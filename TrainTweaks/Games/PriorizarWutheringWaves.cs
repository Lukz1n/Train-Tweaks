using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarWutheringWaves : GamePriorityOperation
{
    public PriorizarWutheringWaves() : base("wutheringwaves", new[] { "Client-Win64-Shipping.exe" }, 3) { }
}
