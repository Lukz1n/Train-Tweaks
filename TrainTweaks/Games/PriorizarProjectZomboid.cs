using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarProjectZomboid : GamePriorityOperation
{
    public PriorizarProjectZomboid() : base("projectzomboid", new[] { "ProjectZomboid64.exe", "ProjectZomboid32.exe" }, 3) { }
}
