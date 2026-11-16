using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarNoMansSky : GamePriorityOperation
{
    public PriorizarNoMansSky() : base("nomanssky", new[] { "NMS.exe" }, 3) { }
}
