using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class PriorizarTarefasForeground : PowerShellOperation
{
    public PriorizarTarefasForeground() : base("Muda o escalonamento para priorizar tarefas em primeiro plano.", true) { }

    protected override string Script => """
$k='HKLM:\SYSTEM\CurrentControlSet\Control\PriorityControl'; Set-ItemProperty $k Win32PrioritySeparation 38 -Type DWord
$g='HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games'; New-Item $g -Force|Out-Null; Set-ItemProperty $g 'GPU Priority' 8 -Type DWord; Set-ItemProperty $g Priority 6 -Type DWord; Set-ItemProperty $g 'Scheduling Category' High -Type String
""";
}
