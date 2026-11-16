using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarVbsHvci : PowerShellOperation
{
    public DesativarVbsHvci() : base("Desativa VBS/HVCI. Reduz proteções de segurança e requer reinicialização.", true) { }

    protected override string Script => """
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard' EnableVirtualizationBasedSecurity 0 -Type DWord
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard' RequirePlatformSecurityFeatures 0 -Type DWord
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity' Enabled 0 -Type DWord
& bcdedit.exe /set hypervisorlaunchtype off
""";
}
