using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarEFootball : GamePriorityOperation
{
    public PriorizarEFootball() : base("efootball", new[] { "eFootball.exe" }, 3) { }
}
