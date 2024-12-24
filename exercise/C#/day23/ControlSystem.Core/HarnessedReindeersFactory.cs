using ControlSystem.External;

namespace ControlSystem.Core;

public class HarnessedReindeersFactory
{
    private readonly ChristmasTown _christmasTown;
    private readonly List<Reindeer> _reindeers;

    private HarnessedReindeersFactory(List<Reindeer> reindeers, ChristmasTown christmasTown)
    {
        _reindeers = reindeers;
        _christmasTown = christmasTown;
    }

    public static HarnessedReindeersFactory CreateFrom(
        MagicStable magicStable,
        ChristmasTown christmasTown)
        => new(magicStable.GetAllReindeers(), christmasTown);

    private ReindeerPowerUnit AttachPowerUnit(Reindeer mostPowerfulReindeer)
        => new(mostPowerfulReindeer, _christmasTown.DistributeMostPowerfulAmplifier());

    public HarnessedReindeers Create()
        => new(
            AllReindeerByMagicalPower()
                .Select(AttachPowerUnit)
                .ToSeq());

    private IOrderedEnumerable<Reindeer> AllReindeerByMagicalPower()
        => _reindeers
            // GetMagicPower contains an issue
            // it should return 0 if the reindeer needs rest
            // so we need to check if the reindeer is sick
            .OrderBy(r => r.Sick)
            .ThenByDescending(r => r.GetMagicPower());
}