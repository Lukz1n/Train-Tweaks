using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDaysGone : GamePriorityOperation
{
    public PriorizarDaysGone() : base("daysgone", new[] { "DaysGone.exe" }, 3) { }
}
