using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarForzaHorizon4 : GamePriorityOperation
{
    public PriorizarForzaHorizon4() : base("forzahorizon4", new[] { "ForzaHorizon4.exe" }, 3) { }
}
