using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarForzaHorizon5 : GamePriorityOperation
{
    public PriorizarForzaHorizon5() : base("forzahorizon5", new[] { "ForzaHorizon5.exe" }, 3) { }
}
