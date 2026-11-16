using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarWarframe : GamePriorityOperation
{
    public PriorizarWarframe() : base("warframe", new[] { "Warframe.x64.exe", "Warframe.exe" }, 3) { }
}
