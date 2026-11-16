using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBattlefield6 : GamePriorityOperation
{
    public PriorizarBattlefield6() : base("battlefield6", new[] { "bf6.exe" }, 3) { }
}
