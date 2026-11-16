using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class OtimizarEnergia : PowerShellOperation
{
    public OtimizarEnergia() : base("Adiciona e ativa o plano de energia de alto desempenho e aplica o ajuste de processador do BAT.", true) { }

    protected override string Script => """
$scheme = (& powercfg.exe -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61 | Select-String -Pattern '[0-9a-fA-F-]{36}' | ForEach-Object { $_.Matches.Value } | Select-Object -First 1)
if ($scheme) { & powercfg.exe /setactive $scheme }
& powercfg.exe /setacvalueindex SCHEME_CURRENT SUB_PROCESSOR IdleDisable 0
& powercfg.exe /setactive SCHEME_CURRENT
""";
}
