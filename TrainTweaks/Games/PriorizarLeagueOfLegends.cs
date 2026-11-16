using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarLeagueOfLegends : GamePriorityOperation
{
    public PriorizarLeagueOfLegends() : base("lol", new[] { "League of Legends.exe" }, 3) { }
}
