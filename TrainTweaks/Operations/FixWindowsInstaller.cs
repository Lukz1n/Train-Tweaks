using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixWindowsInstaller : PowerShellOperation
{
    public FixWindowsInstaller() : base("Registra novamente Windows Installer nas versões 64 e 32 bits.", true) { }

    protected override string Script => """
$root=Join-Path $env:windir 'System32\msiexec.exe'; & $root /unregister; & $root /regserver; $wow=Join-Path $env:windir 'SysWOW64\msiexec.exe'; if(Test-Path $wow){& $wow /unregister; & $wow /regserver}; Get-Service msiserver
""";
}
