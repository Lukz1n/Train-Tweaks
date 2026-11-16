using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarAssettoCorsaCompetizione : GamePriorityOperation
{
    public PriorizarAssettoCorsaCompetizione() : base("assetocorsacompetizione", new[] { "AC2-Win64-Shipping.exe" }, 3) { }
}
