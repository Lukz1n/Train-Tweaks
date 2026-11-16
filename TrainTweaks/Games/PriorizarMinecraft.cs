using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarMinecraft : GamePriorityOperation
{
    public PriorizarMinecraft() : base("minecraft", new[] { "javaw.exe", "Minecraft.Windows.exe" }, 3) { }
}
