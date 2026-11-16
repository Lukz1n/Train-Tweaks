using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarArkSurvivalEvolved : GamePriorityOperation
{
    public PriorizarArkSurvivalEvolved() : base("arksurvivalevolved", new[] { "ShooterGame.exe" }, 3) { }
}
