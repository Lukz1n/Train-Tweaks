using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBlackMythWukong : GamePriorityOperation
{
    public PriorizarBlackMythWukong() : base("blackmythwukong", new[] { "b1-Win64-Shipping.exe" }, 3) { }
}
