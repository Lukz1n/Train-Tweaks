using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPhasmophobia : GamePriorityOperation
{
    public PriorizarPhasmophobia() : base("phasmophobia", new[] { "Phasmophobia.exe" }, 3) { }
}
