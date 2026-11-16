using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixImpressora : PowerShellOperation
{
    public FixImpressora() : base("Reativa o Spooler e abre a lista de impressoras. A fila não é apagada automaticamente.", true) { }

    protected override string Script => """
Set-Service Spooler -StartupType Automatic; Restart-Service Spooler -Force -ErrorAction SilentlyContinue; Start-Process control.exe -ArgumentList 'printers'
""";
}
