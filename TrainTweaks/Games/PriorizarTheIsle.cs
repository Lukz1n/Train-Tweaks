using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarTheIsle : GamePriorityOperation
{
    public PriorizarTheIsle() : base("theisle", new[] { "TheIsleClient-Win64-Shipping.exe" }, 3) { }
}
