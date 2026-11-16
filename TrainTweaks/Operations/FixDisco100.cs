using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixDisco100 : PowerShellOperation
{
    public FixDisco100() : base("Verifica sistema de arquivos e integridade, lista discos e abre Monitor de Recursos.", false) { }

    protected override string Script => """
& chkdsk.exe C: /scan; & sfc.exe /verifyonly; Get-PhysicalDisk | Select-Object FriendlyName,MediaType,HealthStatus,OperationalStatus | Format-Table -AutoSize; Start-Process resmon.exe
""";
}
