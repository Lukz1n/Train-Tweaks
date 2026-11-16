using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDeathStranding : GamePriorityOperation
{
    public PriorizarDeathStranding() : base("deathstranding", new[] { "ds.exe", "DeathStranding.exe" }, 3) { }
}
