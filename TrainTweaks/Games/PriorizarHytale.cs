using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarHytale : GamePriorityOperation
{
    public PriorizarHytale() : base("hytale", new[] { "Hytale.exe" }, 3) { }
}
