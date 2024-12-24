using ControlSystem.External;
using LanguageExt;

namespace ControlSystem.Core;

public class HarnessedReindeers
{
    private readonly Seq<ReindeerPowerUnit> _reindeers;

    private HarnessedReindeers(Seq<ReindeerPowerUnit> reindeers) => _reindeers = reindeers;

    public static HarnessedReindeers CreateFrom(MagicStable magicStable, ChristmasTown christmasTown)
        => new(
            magicStable.GetAllReindeers()
                .OrderBy(r => r.Sick)
                .ThenByDescending(r => r.GetMagicPower())
                .Select<Reindeer, ReindeerPowerUnit>(reindeer => AttachPowerUnit(reindeer, christmasTown))
                .ToSeq());

    private static ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer, ChristmasTown christmasTown)
        => new(reindeer, christmasTown.DistributeMostPowerfulAmplifier());

    public float HarnessMagicPower() => _reindeers.Sum(r => r.HarnessMagicPower());

    public void RestReindeers()
    {
        foreach (var reindeer in _reindeers)
        {
            reindeer.Reindeer.TimesHarnessing = 0;
        }
    }
}