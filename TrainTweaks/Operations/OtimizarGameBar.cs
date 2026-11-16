using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class OtimizarGameBar : PowerShellOperation
{
    public OtimizarGameBar() : base("Desativa recursos de gravação e partes da Xbox Game Bar na conta atual.", false) { }

    protected override string Script => """
$k='HKCU:\System\GameConfigStore'; New-Item $k -Force | Out-Null
Set-ItemProperty $k GameDVR_Enabled 0 -Type DWord; Set-ItemProperty $k GameDVR_FSEBehaviorMode 2 -Type DWord
$k='HKCU:\Software\Microsoft\GameBar'; New-Item $k -Force | Out-Null
Set-ItemProperty $k ShowStartupPanel 0 -Type DWord; Set-ItemProperty $k UseNexusForGameBarEnabled 0 -Type DWord
$k='HKCU:\Software\Microsoft\Windows\CurrentVersion\GameDVR'; New-Item $k -Force | Out-Null; Set-ItemProperty $k AppCaptureEnabled 0 -Type DWord
""";
}
