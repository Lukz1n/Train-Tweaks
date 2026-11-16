using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMultiTheftAuto : GamePriorityOperation
{
    public PriorizarMultiTheftAuto() : base("mta", new[] { "Multi Theft Auto.exe", "gta_sa.exe" }, 3) { }
}
