using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBattlefield2042 : GamePriorityOperation
{
    public PriorizarBattlefield2042() : base("battlefield2042", new[] { "BF2042.exe" }, 3) { }
}
