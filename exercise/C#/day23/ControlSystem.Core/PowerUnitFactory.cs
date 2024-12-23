using ControlSystem.External;

namespace ControlSystem.Core;

public class PowerUnitFactory
{
    private readonly ChristmasTown _christmasTown;
    private readonly MagicStable _magicStable;


    public PowerUnitFactory(MagicStable magicStable, ChristmasTown christmasTown)
    {
        _magicStable = magicStable;
        _christmasTown = christmasTown;
    }

    internal List<ReindeerPowerUnit> BringAllReindeers()
        => _magicStable.GetAllReindeers()
            .OrderBy(r => r.Sick)
            .ThenByDescending(r => r.GetMagicPower())
            .Select<Reindeer, ReindeerPowerUnit>(reindeer => AttachPowerUnit(reindeer, _christmasTown))
            .ToList();

    public ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer, ChristmasTown christmasTown)
        => new(reindeer, christmasTown.DistributeMostPowerfulAmplifier());
}