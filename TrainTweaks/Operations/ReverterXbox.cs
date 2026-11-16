using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class ReverterXbox : PowerShellOperation
{
    public ReverterXbox() : base("Reativa serviços Xbox como manuais, restaura GameDVR e tenta registrar o overlay novamente.", true) { }

    protected override string Script => """
foreach ($n in @('XblAuthManager','XblGameSave','XboxNetApiSvc','XboxGipSvc')) { Set-Service $n -StartupType Manual -ErrorAction SilentlyContinue }
$k='HKCU:\System\GameConfigStore'; New-Item $k -Force | Out-Null; Set-ItemProperty $k GameDVR_Enabled 1 -Type DWord
Get-AppxPackage -AllUsers Microsoft.XboxGamingOverlay | ForEach-Object { if ($_.InstallLocation) { Add-AppxPackage -DisableDevelopmentMode -Register (Join-Path $_.InstallLocation 'AppXManifest.xml') -ErrorAction SilentlyContinue } }
""";
}
