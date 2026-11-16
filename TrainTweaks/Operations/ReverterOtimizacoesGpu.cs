using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class ReverterOtimizacoesGpu : PowerShellOperation
{
    public ReverterOtimizacoesGpu() : base("Remove os ajustes gráficos do BAT e restaura valores usados como padrão pelo script.", true) { }

    protected override string Script => """
Remove-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\Dwm' OverlayTestMode -ErrorAction SilentlyContinue
$gb='HKCU:\Software\Microsoft\GameBar'; Set-ItemProperty $gb AutoGameModeEnabled 1 -Type DWord; Set-ItemProperty $gb AllowAutoGameMode 1 -Type DWord
Remove-ItemProperty 'HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR' AllowGameDVR -ErrorAction SilentlyContinue
Remove-ItemProperty 'HKCU:\System\GameConfigStore' GameDVR_Enabled -ErrorAction SilentlyContinue
Remove-ItemProperty 'HKCU:\System\GameConfigStore' GameDVR_FSEBehaviorMode -ErrorAction SilentlyContinue
Remove-ItemProperty 'HKCU:\System\GameConfigStore' GameDVR_HonorUserFSEBehaviorMode -ErrorAction SilentlyContinue
$sp='HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile'; Set-ItemProperty $sp SystemResponsiveness 20 -Type DWord
$g=Join-Path $sp 'Tasks\Games'; Set-ItemProperty $g 'GPU Priority' 8 -Type DWord; Set-ItemProperty $g Priority 2 -Type DWord; Set-ItemProperty $g 'Scheduling Category' Medium -Type String; Set-ItemProperty $g 'SFIO Priority' Normal -Type String
Set-Service NvTelemetryContainer -StartupType Manual -ErrorAction SilentlyContinue
""";
}
