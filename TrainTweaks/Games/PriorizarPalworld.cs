using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPalworld : GamePriorityOperation
{
    public PriorizarPalworld() : base("palworld", new[] { "Palworld-Win64-Shipping.exe" }, 3) { }
}
