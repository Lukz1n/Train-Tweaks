using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDeltaForce : GamePriorityOperation
{
    public PriorizarDeltaForce() : base("deltaforce", new[] { "DeltaForceClient-Win64-Shipping.exe" }, 3) { }
}
