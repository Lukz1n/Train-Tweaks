using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixReativarWifi : PowerShellOperation
{
    public FixReativarWifi() : base("Reativa serviços de rede e redefine Winsock/IP.", true) { }

    protected override string Script => """
foreach($n in @('WlanSvc','Dhcp','NlaSvc','Netman')){Set-Service $n -StartupType Automatic -ErrorAction SilentlyContinue; Start-Service $n -ErrorAction SilentlyContinue}; & netsh.exe winsock reset; & netsh.exe int ip reset
""";
}
