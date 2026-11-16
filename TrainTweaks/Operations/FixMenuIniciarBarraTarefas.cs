using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixMenuIniciarBarraTarefas : PowerShellOperation
{
    public FixMenuIniciarBarraTarefas() : base("Reinicia o Explorer, a barra de tarefas e o menu Iniciar.", false) { }

    protected override string Script => """
Get-Process explorer -ErrorAction SilentlyContinue | Stop-Process -Force; Start-Sleep -Seconds 2; Start-Process explorer.exe
""";
}
