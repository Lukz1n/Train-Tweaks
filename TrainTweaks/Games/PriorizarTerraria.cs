using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTerraria : GamePriorityOperation
{
    public PriorizarTerraria() : base("terraria", new[] { "Terraria.exe" }, 3) { }
}
