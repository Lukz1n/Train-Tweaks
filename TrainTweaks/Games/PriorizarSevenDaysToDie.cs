using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSevenDaysToDie : GamePriorityOperation
{
    public PriorizarSevenDaysToDie() : base("7daystodie", new[] { "7DaysToDie.exe" }, 3) { }
}
