using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBattlefield4 : GamePriorityOperation
{
    public PriorizarBattlefield4() : base("battlefield4", new[] { "bf4.exe" }, 3) { }
}
