using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarDiabloIV : GamePriorityOperation
{
    public PriorizarDiabloIV() : base("diabloiv", new[] { "Diablo IV.exe" }, 3) { }
}
