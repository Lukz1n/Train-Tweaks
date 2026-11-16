using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDarkSouls3 : GamePriorityOperation
{
    public PriorizarDarkSouls3() : base("darksouls3", new[] { "DarkSoulsIII.exe" }, 3) { }
}
