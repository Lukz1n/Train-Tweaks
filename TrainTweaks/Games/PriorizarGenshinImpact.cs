using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarGenshinImpact : GamePriorityOperation
{
    public PriorizarGenshinImpact() : base("genshin", new[] { "GenshinImpact.exe", "YuanShen.exe" }, 3) { }
}
