using ControlSystem.External;

namespace ControlSystem.Core
{
    public class System
    {
        private const int XmasSpirit = 40;
        public SleighEngineStatus Status => _sleigh.Status;
        public SleighAction Action => _sleigh.Action;

        private readonly Sleigh _sleigh;
        private readonly Dashboard _dashboard;
        private readonly HarnessedReindeers _harnessedReindeers;

        public System()
        {
            _dashboard = new Dashboard();
            _harnessedReindeers = HarnessedReindeersFactory.CreateFrom(new MagicStable(), new ChristmasTown()).Create();
            _sleigh = new Sleigh();
        }

        public void StartSystem()
        {
            _dashboard.DisplayStatus("Starting the sleigh...");
            _sleigh.TurnOn();
            _dashboard.DisplayStatus("System ready.");
        }

        public void Ascend()
        {
            if (_sleigh.Status == SleighEngineStatus.On)
            {
                if (!_harnessedReindeers.HasEnoughPowerToReach(XmasSpirit))
                    throw new ReindeersNeedRestException();
        
                _harnessedReindeers.HarnessAllPower();

                _dashboard.DisplayStatus("Ascending...");
             
                _sleigh.Ascend();
            }
            else throw new SleighNotStartedException();
        }

        public void Descend()
        {
            if (_sleigh.Status == SleighEngineStatus.On)
            {
                _dashboard.DisplayStatus("Descending...");
             
                _sleigh.Descend();
            }
            else throw new SleighNotStartedException();
        }

        public void Park()
        {
            if (_sleigh.Status == SleighEngineStatus.On)
            {
                _harnessedReindeers.RestReindeers();

                _dashboard.DisplayStatus("Parking...");

                _sleigh.Park();
            }
            else throw new SleighNotStartedException();
        }

        public void StopSystem()
        {
            _dashboard.DisplayStatus("Stopping the sleigh...");
            _sleigh.TurnOff();
            _dashboard.DisplayStatus("System shutdown.");
        }
    }
}