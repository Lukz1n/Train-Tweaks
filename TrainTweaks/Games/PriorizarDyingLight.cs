using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDyingLight : GamePriorityOperation
{
    public PriorizarDyingLight() : base("dyinglight", new[] { "DyingLightGame.exe", "DyingLightGame_x64_rwdi.exe" }, 3) { }
}
