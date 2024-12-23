using LanguageExt;

namespace ControlSystem.Core;

public class Sleigh
{
    private const int XmasSpirit = 40;
    private readonly Dashboard _dashboard;
    private readonly Seq<ReindeerPowerUnit> _reindeerPowerUnits;
    private float _controlMagicPower;

    public Sleigh(Dashboard dashboard, PowerUnitFactory powerUnitFactory)
    {
        _dashboard = dashboard;
        _reindeerPowerUnits = powerUnitFactory.BringAllReindeers();
        Action = SleighAction.Parked;
    }

    public SleighAction Action { get; private set; }

    public void Ascend()
    {
        foreach (var reindeerPowerUnit in _reindeerPowerUnits)
        {
            _controlMagicPower += reindeerPowerUnit.HarnessMagicPower();
        }

        if (!CheckReindeerStatus())
            throw new ReindeersNeedRestException();

        _dashboard.DisplayStatus("Ascending...");
        Action = SleighAction.Flying;
        _controlMagicPower = 0;
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

    private bool CheckReindeerStatus() => _controlMagicPower >= XmasSpirit;
}