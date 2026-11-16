using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarEconomiaAdaptadorRede : PowerShellOperation
{
    public DesativarEconomiaAdaptadorRede() : base("Desativa gerenciamento de energia dos adaptadores físicos compatíveis.", true) { }

    protected override string Script => """
Get-NetAdapter -Physical -ErrorAction SilentlyContinue | ForEach-Object { Disable-NetAdapterPowerManagement -Name $_.Name -ErrorAction SilentlyContinue }
""";
}
