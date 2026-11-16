using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMecchaChameleon : GamePriorityOperation
{
    public PriorizarMecchaChameleon() : base("meccha", new[] { "MecchaChameleon.exe" }, 3) { }
}
