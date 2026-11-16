using TrainTweaks.Core;

namespace TrainTweaks.Games;

public sealed class PriorizarProEvolutionSoccer : GamePriorityOperation
{
    public PriorizarProEvolutionSoccer() : base("pes", new[] { "PES2017.exe", "PES2018.exe", "PES2019.exe", "PES2020.exe", "PES2021.exe" }, 3) { }
}
