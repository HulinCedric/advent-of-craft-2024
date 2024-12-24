using ControlSystem.External;
using LanguageExt;

namespace ControlSystem.Core;

public class HarnessedReindeers
{
    private readonly ChristmasTown _christmasTown;
    private readonly MagicStable _magicStable;


    private HarnessedReindeers(MagicStable magicStable, ChristmasTown christmasTown)
    {
        _magicStable = magicStable;
        _christmasTown = christmasTown;
    }

    public static HarnessedReindeers CreateFrom(MagicStable magicStable, ChristmasTown christmasTown)
    {
        return new HarnessedReindeers(magicStable, christmasTown);
    }

    internal Seq<ReindeerPowerUnit> BringAllReindeers()
        => _magicStable.GetAllReindeers()
            .OrderBy(r => r.Sick)
            .ThenByDescending(r => r.GetMagicPower())
            .Select<Reindeer, ReindeerPowerUnit>(reindeer => AttachPowerUnit(reindeer, _christmasTown))
            .ToSeq();

    public ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer, ChristmasTown christmasTown)
        => new(reindeer, christmasTown.DistributeMostPowerfulAmplifier());
}