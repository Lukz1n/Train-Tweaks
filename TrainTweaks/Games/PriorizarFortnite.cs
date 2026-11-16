using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarFortnite : GamePriorityOperation
{
    public PriorizarFortnite() : base("fortnite", new[] { "FortniteClient-Win64-Shipping.exe" }, 3) { }
}
