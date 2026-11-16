using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixAltoUsoRam : PowerShellOperation
{
    public FixAltoUsoRam() : base("Lista processos que mais usam RAM e abre o Gerenciador de Tarefas.", false) { }

    protected override string Script => """
Get-Process | Sort-Object WorkingSet64 -Descending | Select-Object -First 15 ProcessName,Id,@{N='RAM_MB';E={[math]::Round($_.WorkingSet64/1MB,0)}} | Format-Table -AutoSize; Get-CimInstance Win32_OperatingSystem | Select-Object @{N='TotalRAM_MB';E={[math]::Round($_.TotalVisibleMemorySize/1024,0)}},@{N='RAMLivre_MB';E={[math]::Round($_.FreePhysicalMemory/1024,0)}} | Format-Table -AutoSize; Start-Process taskmgr.exe
""";
}
