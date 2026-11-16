using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarGrandTheftAutoV : GamePriorityOperation
{
    public PriorizarGrandTheftAutoV() : base("gtav", new[] { "GTA5.exe", "GTA5_Enhanced.exe" }, 3) { }
}
