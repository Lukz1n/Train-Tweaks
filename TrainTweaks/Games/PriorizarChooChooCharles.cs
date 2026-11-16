using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarChooChooCharles : GamePriorityOperation
{
    public PriorizarChooChooCharles() : base("choochoo", new[] { "Obscure-Win64-Shipping.exe" }, 3) { }
}
