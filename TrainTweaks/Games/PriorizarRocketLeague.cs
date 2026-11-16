using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarRocketLeague : GamePriorityOperation
{
    public PriorizarRocketLeague() : base("rocketleague", new[] { "RocketLeague.exe" }, 3) { }
}
