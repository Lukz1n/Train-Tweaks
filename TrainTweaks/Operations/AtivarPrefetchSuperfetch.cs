using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class AtivarPrefetchSuperfetch : PowerShellOperation
{
    public AtivarPrefetchSuperfetch() : base("Restaura Prefetch e o serviço SysMain para configuração comum do Windows.", true) { }

    protected override string Script => """
Set-Service SysMain -StartupType Automatic; Start-Service SysMain -ErrorAction SilentlyContinue
$k='HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters'; New-Item $k -Force|Out-Null
Set-ItemProperty $k EnablePrefetcher 3 -Type DWord; Set-ItemProperty $k EnableSuperfetch 3 -Type DWord
""";
}
