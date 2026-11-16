using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarF125 : GamePriorityOperation
{
    public PriorizarF125() : base("f125", new[] { "F1_25.exe" }, 3) { }
}
