using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixDll : PowerShellOperation
{
    public FixDll() : base("Executa DISM e SFC. DLLs de terceiros podem exigir reinstalação do aplicativo.", true) { }

    protected override string Script => """
& DISM.exe /Online /Cleanup-Image /RestoreHealth; & sfc.exe /scannow
""";
}
