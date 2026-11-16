using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarResidentEvil4Remake : GamePriorityOperation
{
    public PriorizarResidentEvil4Remake() : base("residentevil4remake", new[] { "re4.exe" }, 3) { }
}
