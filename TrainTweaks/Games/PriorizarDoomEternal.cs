using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDoomEternal : GamePriorityOperation
{
    public PriorizarDoomEternal() : base("doometernal", new[] { "DOOMEternalx64vk.exe" }, 3) { }
}
