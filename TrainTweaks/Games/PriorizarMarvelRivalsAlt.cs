using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMarvelRivalsAlt : GamePriorityOperation
{
    public PriorizarMarvelRivalsAlt() : base("marvel", new[] { "Marvel-Win64-Shipping.exe" }, 3) { }
}
