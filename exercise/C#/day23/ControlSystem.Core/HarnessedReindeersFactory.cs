using ControlSystem.External;

namespace ControlSystem.Core;

public class HarnessedReindeersFactory
{
    private readonly List<Reindeer> _reindeers;
    private readonly ChristmasTown _christmasTown;

    private HarnessedReindeersFactory(List<Reindeer> reindeers, ChristmasTown christmasTown)
    {
        _reindeers = reindeers;
        _christmasTown = christmasTown;
    }

    public static HarnessedReindeersFactory CreateFrom(
        MagicStable magicStable,
        ChristmasTown christmasTown)
        => new(magicStable.GetAllReindeers(), christmasTown);

    private static ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer, ChristmasTown christmasTown)
        => new(reindeer, christmasTown.DistributeMostPowerfulAmplifier());

    public HarnessedReindeers Create()
        => new(
            _reindeers.OrderBy(r => r.Sick)
                .ThenByDescending(r => r.GetMagicPower())
                .Select<Reindeer, ReindeerPowerUnit>(reindeer => AttachPowerUnit(reindeer, _christmasTown))
                .ToSeq());
}