using ControlSystem.External;

namespace ControlSystem.Core
{
    public class System
    {
        private const int XmasSpirit = 40;
        private readonly Dashboard _dashboard;
        private readonly MagicStable _magicStable = new MagicStable();
        private readonly List<ReindeerPowerUnit> _reindeerPowerUnits;
        public SleighEngineStatus Status { get; set; }
        public SleighAction Action { get; set; }
        private float _controlMagicPower = 0;
        private readonly Stack<MagicPowerAmplifier> _christmasTownAmplifiers;

        public System()
        {
            _dashboard = new Dashboard();
            
            _christmasTownAmplifiers = new Stack<MagicPowerAmplifier>();
            _christmasTownAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Divine));
            _christmasTownAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Blessed));
            _christmasTownAmplifiers.Push(new MagicPowerAmplifier(AmplifierType.Blessed));
            
            _reindeerPowerUnits = BringAllReindeers();
        }

        private List<ReindeerPowerUnit> BringAllReindeers() =>
            _magicStable.GetAllReindeers()
                .OrderBy(r => r.NeedsRest())
                .ThenByDescending(r => r.GetMagicPower())
                .Select(AttachPowerUnit)
                .ToList();

        public ReindeerPowerUnit AttachPowerUnit(Reindeer reindeer)
        {
            return new ReindeerPowerUnit(reindeer, GetMagicPowerAmplifier());
        }

        private MagicPowerAmplifier GetMagicPowerAmplifier() 
            => _christmasTownAmplifiers.TryPop(out var amplifier) 
                ? amplifier 
                : new MagicPowerAmplifier(AmplifierType.Basic);

        public void StartSystem()
        {
            _dashboard.DisplayStatus("Starting the sleigh...");
            Status = SleighEngineStatus.On;
            _dashboard.DisplayStatus("System ready.");
        }

        public void Ascend()
        {
            if (Status == SleighEngineStatus.On)
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
            else
            {
                throw new SleighNotStartedException();
            }
        }

        public void Descend()
        {
            if (Status == SleighEngineStatus.On)
            {
                _dashboard.DisplayStatus("Descending...");
                Action = SleighAction.Hovering;
            }
            else throw new SleighNotStartedException();
        }

        public void Park()
        {
            if (Status == SleighEngineStatus.On)
            {
                _dashboard.DisplayStatus("Parking...");

                foreach (var reindeerPowerUnit in _reindeerPowerUnits)
                {
                    reindeerPowerUnit.Reindeer.TimesHarnessing = 0;
                }

                Action = SleighAction.Parked;
            }
            else throw new SleighNotStartedException();
        }

        public void StopSystem()
        {
            _dashboard.DisplayStatus("Stopping the sleigh...");
            Status = SleighEngineStatus.Off;
            _dashboard.DisplayStatus("System shutdown.");
        }

        private bool CheckReindeerStatus()
        {
            return _controlMagicPower >= XmasSpirit;
        }
    }
}