using ControlSystem.External;

namespace ControlSystem.Core;

public class Sleigh
{
    private const int XmasSpirit = 40;
    private readonly Dashboard _dashboard;
    private readonly MagicStable _magicStable = new MagicStable();
    private readonly List<ReindeerPowerUnit> _reindeerPowerUnits;
    private float _controlMagicPower = 0;
    private readonly ChristmasTown _christmasTown = new ChristmasTown();

    public Sleigh(Dashboard dashboard)
    {
        _dashboard = dashboard;
        _reindeerPowerUnits = BringAllReindeers();
        Action = SleighAction.Parked;
    }

    public SleighAction Action { get; private set; }

    private List<ReindeerPowerUnit> BringAllReindeers()
        => _magicStable.GetAllReindeers()
            .OrderBy(r => r.Sick)
            .ThenByDescending(r => r.GetMagicPower())
            .Select(AttachPowerUnit)
            .ToList();

    public ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer)
    {
        return new ReindeerPowerUnit(reindeer, _christmasTown.DistributeMostPowerfulAmplifier());
    }

    public void Ascend()
    {
        foreach (var reindeerPowerUnit in _reindeerPowerUnits)
        {
            _controlMagicPower += reindeerPowerUnit.HarnessMagicPower();
        }

        if (CheckReindeerStatus())
        {
            _dashboard.DisplayStatus("Ascending...");
            Action = SleighAction.Flying;
            _controlMagicPower = 0;
        }
        else throw new ReindeersNeedRestException();
    }

    public void Descend()
    {
        _dashboard.DisplayStatus("Descending...");
        Action = SleighAction.Hovering;
    }

    public void Park()
    {
        _dashboard.DisplayStatus("Parking...");

        foreach (var reindeerPowerUnit in _reindeerPowerUnits)
        {
            reindeerPowerUnit.Reindeer.TimesHarnessing = 0;
        }

        Action = SleighAction.Parked;
    }

    private bool CheckReindeerStatus()
    {
        return _controlMagicPower >= XmasSpirit;
    }
}