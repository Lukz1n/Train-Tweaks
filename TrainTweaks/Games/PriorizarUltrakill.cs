using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarUltrakill : GamePriorityOperation
{
    public PriorizarUltrakill() : base("ultrakill", new[] { "ULTRAKILL.exe" }, 3) { }
}
