using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMetroExodus : GamePriorityOperation
{
    public PriorizarMetroExodus() : base("metroexodus", new[] { "MetroExodus.exe" }, 3) { }
}
