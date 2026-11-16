using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixIconesMiniaturas : PowerShellOperation
{
    public FixIconesMiniaturas() : base("Recria cache de ícones e miniaturas reiniciando o Explorer.", false) { }

    protected override string Script => """
Get-Process explorer -ErrorAction SilentlyContinue|Stop-Process -Force; Start-Sleep -Seconds 2; $paths=@((Join-Path $env:LOCALAPPDATA 'IconCache.db'),(Join-Path $env:LOCALAPPDATA 'Microsoft\Windows\Explorer\iconcache_*.db'),(Join-Path $env:LOCALAPPDATA 'Microsoft\Windows\Explorer\thumbcache_*.db')); foreach($p in $paths){Get-Item $p -ErrorAction SilentlyContinue|Remove-Item -Force -ErrorAction SilentlyContinue}; Start-Process explorer.exe
""";
}
