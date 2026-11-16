using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarCortana : PowerShellOperation
{
    public DesativarCortana() : base("Aplica política da Cortana e remove o pacote quando presente.", true) { }

    protected override string Script => """
$k='HKLM:\SOFTWARE\Policies\Microsoft\Windows\Windows Search'; New-Item $k -Force|Out-Null; Set-ItemProperty $k AllowCortana 0 -Type DWord
Get-AppxPackage '*Microsoft.Windows.Cortana*' | Remove-AppxPackage -ErrorAction SilentlyContinue
""";
}
