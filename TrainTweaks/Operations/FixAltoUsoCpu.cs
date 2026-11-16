using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixAltoUsoCpu : PowerShellOperation
{
    public FixAltoUsoCpu() : base("Exibe processos com maior tempo acumulado de CPU e abre o Gerenciador de Tarefas.", false) { }

    protected override string Script => """
Get-Process | Sort-Object CPU -Descending | Select-Object -First 15 ProcessName,Id,CPU | Format-Table -AutoSize; & sfc.exe /verifyonly; Start-Process taskmgr.exe
""";
}
