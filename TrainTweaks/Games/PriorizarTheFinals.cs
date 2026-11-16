using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTheFinals : GamePriorityOperation
{
    public PriorizarTheFinals() : base("thefinals", new[] { "Discovery.exe" }, 3) { }
}
