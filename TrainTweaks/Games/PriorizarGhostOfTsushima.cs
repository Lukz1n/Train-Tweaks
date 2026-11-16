using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarGhostOfTsushima : GamePriorityOperation
{
    public PriorizarGhostOfTsushima() : base("got", new[] { "GhostOfTsushima.exe" }, 3) { }
}
