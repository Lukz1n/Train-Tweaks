using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDota2 : GamePriorityOperation
{
    public PriorizarDota2() : base("dota2", new[] { "dota2.exe" }, 3) { }
}
