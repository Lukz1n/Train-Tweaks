using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBrawlhalla : GamePriorityOperation
{
    public PriorizarBrawlhalla() : base("brawlhalla", new[] { "Brawlhalla.exe" }, 3) { }
}
