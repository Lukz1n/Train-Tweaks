using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixCamera : PowerShellOperation
{
    public FixCamera() : base("Restaura permissões básicas, reinicia serviços relacionados e verifica arquivos do Windows.", true) { }

    protected override string Script => """
$ErrorActionPreference = 'Continue'
foreach ($name in @('Teams','ms-teams','Zoom','Discord','Skype','obs64','obs32','Camera','WindowsCamera')) {
    Get-Process $name -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
}
$permissionKeys = @(
    'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam',
    'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam',
    'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam\NonPackaged',
    'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam\NonPackaged'
)
foreach ($key in $permissionKeys) { Set-ItemProperty $key Value Allow -Type String }
$policyKeys = @(
    @('HKLM:\SOFTWARE\Policies\Microsoft\Camera','AllowCamera'),
    @('HKCU:\SOFTWARE\Policies\Microsoft\Camera','AllowCamera'),
    @('HKLM:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy','LetAppsAccessCamera'),
    @('HKCU:\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy','LetAppsAccessCamera')
)
foreach ($entry in $policyKeys) { Remove-ItemProperty -Path $entry[0] -Name $entry[1] -ErrorAction SilentlyContinue }
foreach ($service in @('PlugPlay','DeviceInstall','DsmSvc','FrameServer','FrameServerMonitor')) {
    if (Get-Service $service -ErrorAction SilentlyContinue) { Restart-Service $service -Force -ErrorAction SilentlyContinue }
}
Get-Service -ErrorAction SilentlyContinue | Where-Object { $_.Name -like 'CaptureService_*' -or $_.Name -like 'cbdhsvc_*' } | ForEach-Object { Restart-Service $_.Name -Force -ErrorAction SilentlyContinue }
$devices = Get-PnpDevice -PresentOnly:$false -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('Camera','Image') -or $_.FriendlyName -match 'camera|webcam|integrated cam|usb video' }
foreach ($device in $devices) { Enable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue }
& pnputil.exe /scan-devices
Start-Sleep -Seconds 2
$devices = Get-PnpDevice -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('Camera','Image') -or $_.FriendlyName -match 'camera|webcam|integrated cam|usb video' }
foreach ($device in $devices) {
    Disable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue
    Start-Sleep -Milliseconds 700
    Enable-PnpDevice -InstanceId $device.InstanceId -Confirm:$false -ErrorAction SilentlyContinue
}
& DISM.exe /Online /Cleanup-Image /ScanHealth
& DISM.exe /Online /Cleanup-Image /RestoreHealth
& sfc.exe /scannow
if (Get-Command winget.exe -ErrorAction SilentlyContinue) {
    & winget.exe source update --disable-interactivity
    & winget.exe upgrade --id Microsoft.WindowsCamera --accept-source-agreements --accept-package-agreements --silent
}
Get-AppxPackage -AllUsers '*WindowsCamera*' -ErrorAction SilentlyContinue | ForEach-Object {
    $manifest = Join-Path $_.InstallLocation 'AppXManifest.xml'
    if (Test-Path $manifest) { Add-AppxPackage -DisableDevelopmentMode -Register $manifest -ErrorAction SilentlyContinue }
}
Start-Service wuauserv -ErrorAction SilentlyContinue
Start-Service bits -ErrorAction SilentlyContinue
& UsoClient.exe StartScan
& UsoClient.exe StartDownload
Get-PnpDevice -ErrorAction SilentlyContinue | Where-Object { $_.Class -in @('Camera','Image') -or $_.FriendlyName -match 'camera|webcam|usb video' } | Select-Object Status,Class,FriendlyName,Problem,InstanceId
""";
}
