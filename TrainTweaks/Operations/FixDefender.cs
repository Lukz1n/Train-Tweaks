using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixDefender : PowerShellOperation
{
    public FixDefender() : base("Consulta serviços e status do Defender, verifica arquivos e abre Segurança do Windows.", false) { }

    protected override string Script => """
foreach($n in @('WinDefend','SecurityHealthService','wscsvc')){Get-Service $n -ErrorAction SilentlyContinue}; Get-MpComputerStatus | Select-Object AMServiceEnabled,AntivirusEnabled,RealTimeProtectionEnabled; & sfc.exe /scannow; Start-Process 'windowsdefender:'
""";
}
