using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixBluetooth : PowerShellOperation
{
    public FixBluetooth() : base("Reativa o serviço Bluetooth.", true) { }

    protected override string Script => """
Set-Service bthserv -StartupType Automatic; Start-Service bthserv
""";
}
