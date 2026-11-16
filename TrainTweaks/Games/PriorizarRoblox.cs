using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarRoblox : GamePriorityOperation
{
    public PriorizarRoblox() : base("roblox", new[] { "RobloxPlayerBeta.exe" }, 3) { }
}
