using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarAplicativosSegundoPlano : PowerShellOperation
{
    public DesativarAplicativosSegundoPlano() : base("Bloqueia execução global de apps em segundo plano e rastreamento de apps recentes.", false) { }

    protected override string Script => """
$k='HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications'; New-Item $k -Force | Out-Null; Set-ItemProperty $k GlobalUserDisabled 1 -Type DWord
$k='HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced'; Set-ItemProperty $k Start_TrackProgs 0 -Type DWord
""";
}
