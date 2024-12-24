using LanguageExt;

namespace ControlSystem.Core;

public class HarnessedReindeers
{
    private readonly Seq<ReindeerPowerUnit> _reindeers;

    internal HarnessedReindeers(Seq<ReindeerPowerUnit> reindeers) => _reindeers = reindeers;

    public void HarnessAllPower()
    {
        foreach (var reindeer in _reindeers)
        {
            reindeer.HarnessMagicPower();
        }
    }

    public bool HasEnoughPowerToReach(int powerNeeded) => _reindeers.Sum(r => r.CheckMagicPower()) >= powerNeeded;

    public void RestReindeers()
    {
        foreach (var reindeer in _reindeers)
        {
            reindeer.Reindeer.TimesHarnessing = 0;
        }
    }
}