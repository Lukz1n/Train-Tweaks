using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarRust : GamePriorityOperation
{
    public PriorizarRust() : base("rust", new[] { "RustClient.exe" }, 3) { }
}
