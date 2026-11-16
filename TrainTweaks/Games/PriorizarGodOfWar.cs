using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarGodOfWar : GamePriorityOperation
{
    public PriorizarGodOfWar() : base("gow", new[] { "GoW.exe", "GoWR.exe" }, 3) { }
}
