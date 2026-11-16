using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSonsOfTheForest : GamePriorityOperation
{
    public PriorizarSonsOfTheForest() : base("sonsoftheforest", new[] { "SonsOfTheForest.exe" }, 3) { }
}
