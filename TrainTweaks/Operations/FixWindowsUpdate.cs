using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixWindowsUpdate : PowerShellOperation
{
    public FixWindowsUpdate() : base("Recria caches de atualização por renomeação de pastas, mantendo cópias de backup.", true) { }

    protected override string Script => """
$svcs=@('wuauserv','bits','cryptsvc'); foreach($n in $svcs){Stop-Service $n -Force -ErrorAction SilentlyContinue}; $stamp=Get-Date -Format yyyyMMddHHmmss; foreach($p in @((Join-Path $env:windir 'SoftwareDistribution'),(Join-Path $env:windir 'System32\catroot2'))){if(Test-Path $p){Rename-Item $p ($p+'.TrainTweaksBackup.'+$stamp) -ErrorAction SilentlyContinue}}; foreach($n in $svcs){Start-Service $n -ErrorAction SilentlyContinue}
""";
}
