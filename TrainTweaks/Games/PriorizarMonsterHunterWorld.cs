using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMonsterHunterWorld : GamePriorityOperation
{
    public PriorizarMonsterHunterWorld() : base("monsterhunterworld", new[] { "MonsterHunterWorld.exe" }, 3) { }
}
