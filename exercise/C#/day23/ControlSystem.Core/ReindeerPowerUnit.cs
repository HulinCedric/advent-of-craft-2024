using ControlSystem.External;

namespace ControlSystem.Core;

public class ReindeerPowerUnit(Reindeer reindeer, MagicPowerAmplifier magicPowerAmplifier)
{
    public Reindeer Reindeer { get; } = reindeer;

    public void HarnessMagicPower()
    {
        if (Reindeer.NeedsRest())
            return;

        Reindeer.TimesHarnessing++;
    }

    public float CheckMagicPower() => !Reindeer.NeedsRest() ? magicPowerAmplifier.Amplify(Reindeer.GetMagicPower()) : 0;
}