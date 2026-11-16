using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPointBlank : GamePriorityOperation
{
    public PriorizarPointBlank() : base("pointblank", new[] { "PointBlank.exe", "PB.exe" }, 3) { }
}
