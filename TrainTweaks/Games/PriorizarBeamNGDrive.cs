using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBeamNGDrive : GamePriorityOperation
{
    public PriorizarBeamNGDrive() : base("beamngdrive", new[] { "BeamNG.drive.x64.exe" }, 3) { }
}
