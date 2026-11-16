using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarLeft4Dead : GamePriorityOperation
{
    public PriorizarLeft4Dead() : base("left4dead", new[] { "left4dead.exe", "left4dead2.exe" }, 3) { }
}
