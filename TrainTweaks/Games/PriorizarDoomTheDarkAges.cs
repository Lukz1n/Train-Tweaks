using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDoomTheDarkAges : GamePriorityOperation
{
    public PriorizarDoomTheDarkAges() : base("doomthedarkages", new[] { "DOOMTheDarkAges.exe" }, 3) { }
}
