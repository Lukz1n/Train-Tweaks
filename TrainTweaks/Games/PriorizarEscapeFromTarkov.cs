using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarEscapeFromTarkov : GamePriorityOperation
{
    public PriorizarEscapeFromTarkov() : base("escapefromtarkov", new[] { "EscapeFromTarkov.exe" }, 3) { }
}
