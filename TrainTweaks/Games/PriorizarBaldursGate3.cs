using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarBaldursGate3 : GamePriorityOperation
{
    public PriorizarBaldursGate3() : base("baldursgate3", new[] { "bg3.exe", "bg3_dx11.exe" }, 3) { }
}
