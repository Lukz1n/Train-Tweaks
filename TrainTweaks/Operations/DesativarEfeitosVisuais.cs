using TrainTweaks.Core;

namespace TrainTweaks.Operations;

public sealed class DesativarEfeitosVisuais : PowerShellOperation
{
    public DesativarEfeitosVisuais() : base("Desativa efeitos visuais e transparência da sessão atual.", false) { }

    protected override string Script => """
New-Item 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects' -Force | Out-Null
Set-ItemProperty 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects' VisualFXSetting 2 -Type DWord
New-Item 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize' -Force | Out-Null
Set-ItemProperty 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize' EnableTransparency 0 -Type DWord
Set-ItemProperty 'HKCU:\Control Panel\Desktop' VisualFXSetting 2 -Type DWord
Set-ItemProperty 'HKCU:\Control Panel\Desktop' UserPreferencesMask ([byte[]](0x90,0x12,0x03,0x80,0x10,0,0,0)) -Type Binary
""";
}
