using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarHogwartsLegacy : GamePriorityOperation
{
    public PriorizarHogwartsLegacy() : base("hogwartslegacy", new[] { "HogwartsLegacy.exe" }, 3) { }
}
