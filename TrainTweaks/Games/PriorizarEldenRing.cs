using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarEldenRing : GamePriorityOperation
{
    public PriorizarEldenRing() : base("eldenring", new[] { "eldenring.exe" }, 3) { }
}
