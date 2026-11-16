using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DebloaterWindows : PowerShellOperation
{
    public DebloaterWindows() : base("Remove pacotes Appx da lista do BAT da conta atual; pode remover apps que você utiliza.", true) { }

    protected override string Script => """
$patterns=@('*Microsoft.Windows.Cortana*','*officehub*','*phone*','*people*','*music*','*messaging*','*maps*','*groove*','*getstarted*','*calendar*','*alarms*','*3dbuilder*','*news*','*onedrive*','*FeedbackHub*','*windowscommunicationsapps*','*QuickAssist*','*solitaire*','*Weather*')
foreach($pattern in $patterns){ Get-AppxPackage $pattern | Remove-AppxPackage -ErrorAction SilentlyContinue }
""";
}
