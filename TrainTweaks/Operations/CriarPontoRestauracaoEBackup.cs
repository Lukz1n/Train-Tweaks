using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class CriarPontoRestauracaoEBackup : PowerShellOperation
{
    public CriarPontoRestauracaoEBackup() : base("Cria um ponto de restauração e exporta as chaves de Registro para a pasta Backup.", true) { }

    protected override string Script => """
$ErrorActionPreference = 'Stop'
$description = 'Train Tweaks RestorePoint'
try { Checkpoint-Computer -Description $description -RestorePointType MODIFY_SETTINGS } catch { throw "Não foi possível criar o ponto de restauração: $($_.Exception.Message)" }
$backup = Join-Path $PWD.Path 'Backup'
New-Item -ItemType Directory -Path $backup -Force | Out-Null
$keys = @(
  @{Path='HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer'; File='Explorer.reg'},
  @{Path='HKCU\Software\Microsoft\GameBar'; File='GameBar.reg'},
  @{Path='HKCU\System\GameConfigStore'; File='GameConfigStore.reg'},
  @{Path='HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile'; File='SystemProfile.reg'},
  @{Path='HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games'; File='Games.reg'},
  @{Path='HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management'; File='MemoryManagement.reg'},
  @{Path='HKLM\SYSTEM\CurrentControlSet\Services\Tcpip'; File='Tcpip.reg'},
  @{Path='HKLM\SYSTEM\CurrentControlSet\Control\GraphicsDrivers'; File='GraphicsDrivers.reg'},
  @{Path='HKCU\Control Panel\Mouse'; File='Mouse.reg'},
  @{Path='HKCU\Control Panel\Keyboard'; File='Keyboard.reg'},
  @{Path='HKCU\Control Panel\Desktop'; File='Desktop.reg'}
)
foreach ($key in $keys) { & reg.exe export $key.Path (Join-Path $backup $key.File) /y | Out-Null }
""";
}
