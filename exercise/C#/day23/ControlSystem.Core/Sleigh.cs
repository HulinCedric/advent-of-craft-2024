namespace ControlSystem.Core;

public class Sleigh
{
    private const int XmasSpirit = 40;
    private readonly Dashboard _dashboard;
    private readonly HarnessedReindeers _harnessedReindeers;

    public Sleigh(Dashboard dashboard, HarnessedReindeers harnessedReindeers)
    {
        _dashboard = dashboard;
        _harnessedReindeers = harnessedReindeers;
        Action = SleighAction.Parked;
    }

    public SleighAction Action { get; private set; }

    public void Ascend()
    {
        if (CannotAscendWith(_harnessedReindeers.CheckHarnessMagicPower()))
            throw new ReindeersNeedRestException();
        
        _harnessedReindeers.HarnessMagicPower();

        _dashboard.DisplayStatus("Ascending...");
        Action = SleighAction.Flying;
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

    private static bool CannotAscendWith(float magicPower) => magicPower < XmasSpirit;
}