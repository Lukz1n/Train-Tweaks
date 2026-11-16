using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarHelldivers2 : GamePriorityOperation
{
    public PriorizarHelldivers2() : base("helldivers2", new[] { "helldivers2.exe" }, 3) { }
}
