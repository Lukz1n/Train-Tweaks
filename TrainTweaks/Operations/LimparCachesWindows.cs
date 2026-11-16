using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class LimparCachesWindows : PowerShellOperation
{
    public LimparCachesWindows() : base("Limpa temporários, arquivos recentes, cache baixado do Windows Update e lixeira; arquivos em uso são ignorados.", true) { }

    protected override string Script => """
$ErrorActionPreference='Continue'
$paths=@($env:windir+'\Temp',$env:TEMP,(Join-Path $env:APPDATA 'Microsoft\Windows\Recent'),(Join-Path $env:windir 'SoftwareDistribution\Download'))
foreach($path in $paths){ if(Test-Path -LiteralPath $path){ Get-ChildItem -LiteralPath $path -Force -ErrorAction SilentlyContinue | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue } }
& ipconfig.exe /flushdns
try { Clear-RecycleBin -Force -ErrorAction SilentlyContinue } catch {}
""";
}
