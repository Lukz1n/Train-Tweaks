using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTheLastOfUs : GamePriorityOperation
{
    public PriorizarTheLastOfUs() : base("tlol", new[] { "tlou-i.exe", "tlou-ii.exe" }, 3) { }
}
