using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMarvelRivals : GamePriorityOperation
{
    public PriorizarMarvelRivals() : base("marvelrivals", new[] { "Marvel-Win64-Shipping.exe" }, 3) { }
}
