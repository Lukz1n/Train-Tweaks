using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarLiesOfP : GamePriorityOperation
{
    public PriorizarLiesOfP() : base("liesofp", new[] { "LOP-Win64-Shipping.exe" }, 3) { }
}
