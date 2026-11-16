using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class OtimizarMenuIniciar : PowerShellOperation
{
    public OtimizarMenuIniciar() : base("Desativa resultados online/Bing e sugestões da caixa de pesquisa.", false) { }

    protected override string Script => """
$k='HKCU:\Software\Microsoft\Windows\CurrentVersion\Search'; New-Item $k -Force|Out-Null
Set-ItemProperty $k BingSearchEnabled 0 -Type DWord; Set-ItemProperty $k CortanaConsent 0 -Type DWord; Set-ItemProperty $k SearchboxTaskbarMode 0 -Type DWord
$k='HKCU:\Software\Policies\Microsoft\Windows\Explorer'; New-Item $k -Force|Out-Null; Set-ItemProperty $k DisableSearchBoxSuggestions 1 -Type DWord
""";
}
