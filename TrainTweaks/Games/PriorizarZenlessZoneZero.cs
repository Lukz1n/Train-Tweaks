using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarZenlessZoneZero : GamePriorityOperation
{
    public PriorizarZenlessZoneZero() : base("zenlesszonezero", new[] { "ZenlessZoneZero.exe" }, 3) { }
}
