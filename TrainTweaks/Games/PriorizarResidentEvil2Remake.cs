using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarResidentEvil2Remake : GamePriorityOperation
{
    public PriorizarResidentEvil2Remake() : base("residentevil2remake", new[] { "re2.exe" }, 3) { }
}
