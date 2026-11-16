using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixMicrofone : PowerShellOperation
{
    public FixMicrofone() : base("Restaura permissões de microfone, reinicia serviços de áudio e verifica o Windows.", true) { }

    protected override string Script => """
$ErrorActionPreference = 'Continue'
try { Enable-ComputerRestore -Drive ($env:SystemDrive + '\') -ErrorAction SilentlyContinue; Checkpoint-Computer -Description 'Antes do FIX Microfone' -RestorePointType MODIFY_SETTINGS -ErrorAction SilentlyContinue } catch { }
foreach ($name in @('Teams','ms-teams','Zoom','Discord','Skype','obs64','obs32')) {
    Get-Process $name -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
}
$permissionKeys = @(
    'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone',
    'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone',
    'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone\NonPackaged',
    'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone\NonPackaged'
)
foreach ($key in $permissionKeys) { Set-ItemProperty $key Value Allow -Type String }
foreach ($hive in @('HKLM:','HKCU:')) {
    Remove-ItemProperty -Path (Join-Path $hive 'SOFTWARE\Policies\Microsoft\Windows\AppPrivacy') -Name LetAppsAccessMicrophone -ErrorAction SilentlyContinue
}
foreach ($name in @('AudioEndpointBuilder','Audiosrv','PlugPlay')) {
    Set-Service $name -StartupType Automatic -ErrorAction SilentlyContinue
    Restart-Service $name -Force -ErrorAction SilentlyContinue
}
$devices = Get-PnpDevice -PresentOnly:$false -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('AudioEndpoint','MEDIA') -or $_.FriendlyName -match 'microphone|microfone|mic|audio|headset' }
foreach ($device in $devices) { Enable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue }
& pnputil.exe /scan-devices
Start-Sleep -Seconds 2
$devices = Get-PnpDevice -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('AudioEndpoint','MEDIA') -and $_.Status -ne 'Unknown' }
foreach ($device in $devices) {
    Disable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue
    Start-Sleep -Milliseconds 500
    Enable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue
}
foreach ($name in @('Audiosrv','AudioEndpointBuilder')) { Restart-Service $name -Force -ErrorAction SilentlyContinue }
& DISM.exe /Online /Cleanup-Image /ScanHealth
& DISM.exe /Online /Cleanup-Image /RestoreHealth
& sfc.exe /scannow
Start-Service wuauserv -ErrorAction SilentlyContinue
Start-Service bits -ErrorAction SilentlyContinue
& UsoClient.exe StartScan
& UsoClient.exe StartDownload
Start-Process 'ms-settings:sound'
Get-PnpDevice -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('AudioEndpoint','MEDIA') -or $_.FriendlyName -match 'microphone|microfone|mic|audio|headset' } | Select-Object Status,Class,FriendlyName,Problem,InstanceId
""";
}
