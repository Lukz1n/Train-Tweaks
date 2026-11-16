using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarCyberpunk2077 : GamePriorityOperation
{
    public PriorizarCyberpunk2077() : base("cyberpunk", new[] { "Cyberpunk2077.exe" }, 3) { }
}
