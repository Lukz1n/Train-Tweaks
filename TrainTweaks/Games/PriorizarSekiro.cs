using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSekiro : GamePriorityOperation
{
    public PriorizarSekiro() : base("sekiroshadowsdietwice", new[] { "sekiro.exe" }, 3) { }
}
