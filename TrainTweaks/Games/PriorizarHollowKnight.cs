using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarHollowKnight : GamePriorityOperation
{
    public PriorizarHollowKnight() : base("hollowknight", new[] { "hollow_knight.exe" }, 3) { }
}
