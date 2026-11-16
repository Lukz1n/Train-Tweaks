using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class RenovarConexaoDeRede : PowerShellOperation
{
    public RenovarConexaoDeRede() : base("Limpa o cache DNS e renova o endereço IP; a conexão pode cair por alguns segundos.", true) { }

    protected override string Script => """
$ErrorActionPreference = 'Stop'
& ipconfig.exe /flushdns
& ipconfig.exe /release
& ipconfig.exe /renew
""";
}
