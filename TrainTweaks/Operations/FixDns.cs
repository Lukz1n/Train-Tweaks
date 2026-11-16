using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixDns : PowerShellOperation
{
    public FixDns() : base("Limpa cache DNS e consulta a resolução de microsoft.com.", false) { }

    protected override string Script => """
& ipconfig.exe /flushdns; & nslookup.exe microsoft.com
""";
}
