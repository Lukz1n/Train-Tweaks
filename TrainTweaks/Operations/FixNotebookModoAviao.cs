using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixNotebookModoAviao : PowerShellOperation
{
    public FixNotebookModoAviao() : base("Reativa os serviços de rádio e Wi-Fi.", true) { }

    protected override string Script => """
foreach($n in @('RmSvc','WlanSvc')){Set-Service $n -StartupType Automatic -ErrorAction SilentlyContinue; Start-Service $n -ErrorAction SilentlyContinue}
""";
}
