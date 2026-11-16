using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMonsterHunterWilds : GamePriorityOperation
{
    public PriorizarMonsterHunterWilds() : base("monsterhunterwilds", new[] { "MonsterHunterWilds.exe" }, 3) { }
}
