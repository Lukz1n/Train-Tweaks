using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTheForest : GamePriorityOperation
{
    public PriorizarTheForest() : base("theforest", new[] { "TheForest.exe" }, 3) { }
}
