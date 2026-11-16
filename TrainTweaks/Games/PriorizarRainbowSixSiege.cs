using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarRainbowSixSiege : GamePriorityOperation
{
    public PriorizarRainbowSixSiege() : base("r6", new[] { "RainbowSix.exe", "RainbowSix_Vulkan.exe" }, 3) { }
}
