using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarValorant : GamePriorityOperation
{
    public PriorizarValorant() : base("valorant", new[] { "VALORANT-Win64-Shipping.exe" }, 3) { }
}
