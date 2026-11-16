using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class FixWindowsHello : PowerShellOperation
{
    public FixWindowsHello() : base("Consulta serviços do Windows Hello, verifica arquivos e abre opções de entrada.", false) { }

    protected override string Script => """
foreach($n in @('NgcSvc','NgcCtnrSvc','WbioSrvc')){Get-Service $n -ErrorAction SilentlyContinue}; & sfc.exe /scannow; Start-Process 'ms-settings:signinoptions'
""";
}
