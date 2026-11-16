using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarResidentEvilVillage : GamePriorityOperation
{
    public PriorizarResidentEvilVillage() : base("residentevilvillage", new[] { "re8.exe" }, 3) { }
}
