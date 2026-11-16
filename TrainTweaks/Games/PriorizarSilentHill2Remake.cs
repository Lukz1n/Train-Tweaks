using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarSilentHill2Remake : GamePriorityOperation
{
    public PriorizarSilentHill2Remake() : base("silenthill2remake", new[] { "SHProto-Win64-Shipping.exe" }, 3) { }
}
