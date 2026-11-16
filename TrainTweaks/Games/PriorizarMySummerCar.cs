using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMySummerCar : GamePriorityOperation
{
    public PriorizarMySummerCar() : base("mysummercar", new[] { "mysummercar.exe" }, 3) { }
}
