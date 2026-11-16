using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixRedeInternet : PowerShellOperation
{
    public FixRedeInternet() : base("Renova a configuração IP e redefine pilha TCP/IP e Winsock.", true) { }

    protected override string Script => """
& ipconfig.exe /flushdns; & ipconfig.exe /release; & ipconfig.exe /renew; & netsh.exe int ip reset; & netsh.exe winsock reset
""";
}
