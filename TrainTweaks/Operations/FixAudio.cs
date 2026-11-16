using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixAudio : PowerShellOperation
{
    public FixAudio() : base("Reativa e reinicia os serviços de áudio.", true) { }

    protected override string Script => """
foreach($n in @('Audiosrv','AudioEndpointBuilder')){Set-Service $n -StartupType Automatic; Start-Service $n -ErrorAction SilentlyContinue}; Restart-Service Audiosrv -Force -ErrorAction SilentlyContinue
""";
}
