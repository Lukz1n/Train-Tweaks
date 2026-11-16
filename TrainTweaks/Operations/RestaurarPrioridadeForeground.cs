using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class RestaurarPrioridadeForeground : PowerShellOperation
{
    public RestaurarPrioridadeForeground() : base("Restaura valores padrão usuais do escalonamento de primeiro plano e tarefas de jogos.", true) { }

    protected override string Script => """
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\PriorityControl' Win32PrioritySeparation 2 -Type DWord
$g='HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games'; Set-ItemProperty $g Priority 2 -Type DWord; Set-ItemProperty $g 'Scheduling Category' Medium -Type String
""";
}
