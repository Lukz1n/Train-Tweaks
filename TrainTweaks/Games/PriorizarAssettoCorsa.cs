using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarAssettoCorsa : GamePriorityOperation
{
    public PriorizarAssettoCorsa() : base("assettocorsa", new[] { "acs.exe" }, 3) { }
}
