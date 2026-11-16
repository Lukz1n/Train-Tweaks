using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBloodStrike : GamePriorityOperation
{
    public PriorizarBloodStrike() : base("bloodstrike", new[] { "BloodStrike.exe" }, 3) { }
}
