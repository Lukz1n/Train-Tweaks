using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTeamFortress2 : GamePriorityOperation
{
    public PriorizarTeamFortress2() : base("teamfortress2", new[] { "tf_win64.exe", "hl2.exe" }, 3) { }
}
