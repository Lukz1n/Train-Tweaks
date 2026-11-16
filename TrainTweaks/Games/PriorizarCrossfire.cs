using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarCrossfire : GamePriorityOperation
{
    public PriorizarCrossfire() : base("crossfire", new[] { "crossfire.exe" }, 3) { }
}
