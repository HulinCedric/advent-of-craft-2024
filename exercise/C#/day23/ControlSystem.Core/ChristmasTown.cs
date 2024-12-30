namespace ControlSystem.Core;

public class ChristmasTown
{
    private readonly Stack<MagicPowerAmplifier> _availableAmplifiers;

    public ChristmasTown()
    {
        _availableAmplifiers = new Stack<MagicPowerAmplifier>();
        _availableAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Blessed));
        _availableAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Blessed));
        _availableAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Divine));
    }

    public MagicPowerAmplifier DistributeMostPowerfulAmplifier()
        => _availableAmplifiers.TryPop(out var amplifier)
            ? amplifier
            : new MagicPowerAmplifier(AmplifierType.Basic);
}