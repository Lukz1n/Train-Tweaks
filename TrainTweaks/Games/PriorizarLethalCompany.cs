using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarLethalCompany : GamePriorityOperation
{
    public PriorizarLethalCompany() : base("lethalcompany", new[] { "Lethal Company.exe" }, 3) { }
}
