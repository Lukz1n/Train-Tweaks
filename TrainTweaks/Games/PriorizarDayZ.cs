using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDayZ : GamePriorityOperation
{
    public PriorizarDayZ() : base("dayz", new[] { "DayZ_x64.exe" }, 3) { }
}
