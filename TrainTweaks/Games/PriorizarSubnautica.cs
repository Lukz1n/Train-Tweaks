using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSubnautica : GamePriorityOperation
{
    public PriorizarSubnautica() : base("subnautica", new[] { "Subnautica.exe", "SubnauticaZero.exe" }, 3) { }
}
