using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFinalFantasyXIV : GamePriorityOperation
{
    public PriorizarFinalFantasyXIV() : base("ffxiv", new[] { "ffxiv_dx11.exe", "ffxiv.exe" }, 3) { }
}
