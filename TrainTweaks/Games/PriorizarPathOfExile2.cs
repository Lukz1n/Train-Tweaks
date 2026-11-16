using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPathOfExile2 : GamePriorityOperation
{
    public PriorizarPathOfExile2() : base("pathofexile2", new[] { "PathOfExileSteam.exe", "PathOfExile_x64.exe" }, 3) { }
}
