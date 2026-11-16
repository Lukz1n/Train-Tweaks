using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarReadyOrNot : GamePriorityOperation
{
    public PriorizarReadyOrNot() : base("readyornot", new[] { "ReadyOrNot-Win64-Shipping.exe" }, 3) { }
}
