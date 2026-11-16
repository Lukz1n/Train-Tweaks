using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarCuphead : GamePriorityOperation
{
    public PriorizarCuphead() : base("cuphead", new[] { "Cuphead.exe" }, 3) { }
}
