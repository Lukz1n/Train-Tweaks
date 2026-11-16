using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixExplorador : PowerShellOperation
{
    public FixExplorador() : base("Reinicia o Explorer.", false) { }

    protected override string Script => """
Get-Process explorer -ErrorAction SilentlyContinue|Stop-Process -Force; Start-Sleep -Seconds 2; Start-Process explorer.exe
""";
}
