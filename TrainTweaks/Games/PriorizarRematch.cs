using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarRematch : GamePriorityOperation
{
    public PriorizarRematch() : base("rematch", new[] { "Rematch-Win64-Shipping.exe" }, 3) { }
}
