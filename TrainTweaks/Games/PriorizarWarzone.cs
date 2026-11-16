using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarWarzone : GamePriorityOperation
{
    public PriorizarWarzone() : base("warzone", new[] { "cod.exe" }, 3) { }
}
