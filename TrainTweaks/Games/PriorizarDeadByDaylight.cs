using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDeadByDaylight : GamePriorityOperation
{
    public PriorizarDeadByDaylight() : base("dbd", new[] { "DeadByDaylight-Win64-Shipping.exe" }, 3) { }
}
