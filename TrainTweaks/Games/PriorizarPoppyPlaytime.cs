using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarPoppyPlaytime : GamePriorityOperation
{
    public PriorizarPoppyPlaytime() : base("poppyplaytime", new[] { "Poppy_Playtime-Win64-Shipping.exe", "Playtime_Prototype4-Win64-Shipping.exe" }, 3) { }
}
