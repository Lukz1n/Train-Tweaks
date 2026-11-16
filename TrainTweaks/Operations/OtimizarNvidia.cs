using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class OtimizarNvidia : PowerShellOperation
{
    public OtimizarNvidia() : base("Aplica o perfil gráfico selecionado e configura prioridade de jogos.", true) { }

    protected override string Script => """
$gb='HKCU:\Software\Microsoft\GameBar'; New-Item $gb -Force|Out-Null; Set-ItemProperty $gb ShowStartupPanel 0 -Type DWord; Set-ItemProperty $gb AllowAutoGameMode 1 -Type DWord; Set-ItemProperty $gb AutoGameModeEnabled 1 -Type DWord
$gc='HKCU:\System\GameConfigStore'; New-Item $gc -Force|Out-Null; Set-ItemProperty $gc GameDVR_Enabled 0 -Type DWord; Set-ItemProperty $gc GameDVR_FSEBehaviorMode 2 -Type DWord; Set-ItemProperty $gc GameDVR_HonorUserFSEBehaviorMode 1 -Type DWord
$sp='HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile'; New-Item $sp -Force|Out-Null; Set-ItemProperty $sp SystemResponsiveness 0 -Type DWord
$g=Join-Path $sp 'Tasks\Games'; New-Item $g -Force|Out-Null; Set-ItemProperty $g 'GPU Priority' 8 -Type DWord; Set-ItemProperty $g Priority 6 -Type DWord; Set-ItemProperty $g 'Scheduling Category' High -Type String; Set-ItemProperty $g 'SFIO Priority' High -Type String
Set-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\Dwm' OverlayTestMode 5 -Type DWord; Stop-Service NvTelemetryContainer -Force -ErrorAction SilentlyContinue; Set-Service NvTelemetryContainer -StartupType Disabled -ErrorAction SilentlyContinue
""";
}
