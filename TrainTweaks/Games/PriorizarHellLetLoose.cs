using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarHellLetLoose : GamePriorityOperation
{
    public PriorizarHellLetLoose() : base("hll", new[] { "HLL-Win64-Shipping.exe" }, 3) { }
}
