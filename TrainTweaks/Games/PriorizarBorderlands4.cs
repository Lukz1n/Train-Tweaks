using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBorderlands4 : GamePriorityOperation
{
    public PriorizarBorderlands4() : base("borderlands4", new[] { "OakGame-Win64-Shipping.exe" }, 3) { }
}
