using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarIsolamentoDeNucleo : PowerShellOperation
{
    public DesativarIsolamentoDeNucleo() : base("Desativa VBS/HVCI e o hypervisor no boot. Reduz proteções de segurança; requer reinicialização.", true) { }

    protected override string Script => """
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard' EnableVirtualizationBasedSecurity 0 -Type DWord
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\Lsa' LsaCfgFlags 0 -Type DWord
Set-ItemProperty 'HKLM:\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity' Enabled 0 -Type DWord
& bcdedit.exe /set hypervisorlaunchtype off
""";
}
