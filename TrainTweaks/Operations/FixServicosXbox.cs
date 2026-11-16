using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixServicosXbox : PowerShellOperation
{
    public FixServicosXbox() : base("Configura serviços Xbox como manuais.", true) { }

    protected override string Script => """
foreach($n in @('XblAuthManager','XblGameSave','XboxNetApiSvc')){Set-Service $n -StartupType Manual -ErrorAction SilentlyContinue}
""";
}
