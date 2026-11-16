using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFiveM : GamePriorityOperation
{
    public PriorizarFiveM() : base("fivem", new[] { "FiveM_b3095_GTAProcess.exe", "FiveM_b3258_GTAProcess.exe" }, 3) { }
}
