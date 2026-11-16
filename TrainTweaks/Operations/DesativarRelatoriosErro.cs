using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarRelatoriosErro : PowerShellOperation
{
    public DesativarRelatoriosErro() : base("Desativa o Windows Error Reporting e seu serviço.", true) { }

    protected override string Script => """
$k='HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting'; New-Item $k -Force | Out-Null; Set-ItemProperty $k Disabled 1 -Type DWord
Stop-Service WerSvc -Force -ErrorAction SilentlyContinue; Set-Service WerSvc -StartupType Disabled
""";
}
