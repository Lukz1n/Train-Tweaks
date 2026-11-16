using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarStreetFighter6 : GamePriorityOperation
{
    public PriorizarStreetFighter6() : base("sf6", new[] { "StreetFighter6.exe" }, 3) { }
}
