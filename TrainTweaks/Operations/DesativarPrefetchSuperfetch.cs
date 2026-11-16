using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarPrefetchSuperfetch : PowerShellOperation
{
    public DesativarPrefetchSuperfetch() : base("Desativa Prefetch/SysMain. O efeito varia conforme o tipo de armazenamento e o uso.", true) { }

    protected override string Script => """
$k='HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters'; New-Item $k -Force|Out-Null
Set-ItemProperty $k EnablePrefetcher 0 -Type DWord; Set-ItemProperty $k EnableSuperfetch 0 -Type DWord
Stop-Service SysMain -Force -ErrorAction SilentlyContinue; Set-Service SysMain -StartupType Disabled
""";
}
