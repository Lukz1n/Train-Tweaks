using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSkyrim : GamePriorityOperation
{
    public PriorizarSkyrim() : base("skyrim", new[] { "TESV.exe", "SkyrimSE.exe" }, 3) { }
}
