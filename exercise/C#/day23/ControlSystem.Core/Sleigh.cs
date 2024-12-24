namespace ControlSystem.Core;

public class Sleigh
{
    private const int XmasSpirit = 40;
    private readonly Dashboard _dashboard;
    private readonly HarnessedReindeers _harnessedReindeers;
    private float _controlMagicPower;

    public Sleigh(Dashboard dashboard, HarnessedReindeers harnessedReindeers)
    {
        _dashboard = dashboard;
        _harnessedReindeers = harnessedReindeers;
        Action = SleighAction.Parked;
    }

    public SleighAction Action { get; private set; }

    public void Ascend()
    {
        _controlMagicPower += _harnessedReindeers.HarnessMagicPower();

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
        _harnessedReindeers.RestReindeers();
        Action = SleighAction.Parked;
    }

    private bool CheckReindeerStatus() => _controlMagicPower >= XmasSpirit;
}