using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarStalker2 : GamePriorityOperation
{
    public PriorizarStalker2() : base("stalker2", new[] { "Stalker2-Win64-Shipping.exe" }, 3) { }
}
