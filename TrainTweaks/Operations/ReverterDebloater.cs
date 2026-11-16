using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class ReverterDebloater : PowerShellOperation
{
    public ReverterDebloater() : base("Tenta registrar novamente pacotes Appx instalados. Não restaura todos os apps removidos ou dados apagados.", true) { }

    protected override string Script => """
Get-AppxPackage -AllUsers | ForEach-Object { $manifest=Join-Path $_.InstallLocation 'AppxManifest.xml'; if($_.InstallLocation -and (Test-Path $manifest)){ Add-AppxPackage -DisableDevelopmentMode -Register $manifest -ErrorAction SilentlyContinue } }
""";
}
