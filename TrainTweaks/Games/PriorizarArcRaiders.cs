using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarArcRaiders : GamePriorityOperation
{
    public PriorizarArcRaiders() : base("arcraiders", new[] { "PioneerGame.exe" }, 3) { }
}
