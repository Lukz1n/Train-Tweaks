using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class PrioridadeCpuGpuJogos : PowerShellOperation
{
    public PrioridadeCpuGpuJogos() : base("Aplica a prioridade multimídia usada pelo BAT para tarefas de jogos.", true) { }

    protected override string Script => """
$root='HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile'; New-Item $root -Force|Out-Null; Set-ItemProperty $root SystemResponsiveness 0 -Type DWord
$g=Join-Path $root 'Tasks\Games'; New-Item $g -Force|Out-Null; Set-ItemProperty $g 'GPU Priority' 8 -Type DWord; Set-ItemProperty $g Priority 6 -Type DWord; Set-ItemProperty $g 'Scheduling Category' 'High' -Type String; Set-ItemProperty $g 'SFIO Priority' 'High' -Type String
""";
}
