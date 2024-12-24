using ControlSystem.External;

namespace ControlSystem.Core
{
    public class System
    {
        public SleighEngineStatus Status { get; private set; }
        public SleighAction Action => _sleigh.Action;

        private readonly Sleigh _sleigh;
        private readonly Dashboard _dashboard;

        public System()
        {
            _dashboard = new Dashboard();
            var harnessedReindeers = HarnessedReindeers.CreateFrom(new MagicStable(), new ChristmasTown());
            _sleigh = new Sleigh(_dashboard, harnessedReindeers);
        }

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
                _sleigh.Ascend();
            }
            else throw new SleighNotStartedException();
        }

        public void Descend()
        {
            if (Status == SleighEngineStatus.On)
            {
                _sleigh.Descend();
            }
            else throw new SleighNotStartedException();
        }

        public void Park()
        {
            if (Status == SleighEngineStatus.On)
            {
                _sleigh.Park();
            }
            else throw new SleighNotStartedException();
        }

        public void StopSystem()
        {
            _dashboard.DisplayStatus("Stopping the sleigh...");
            Status = SleighEngineStatus.Off;
            _dashboard.DisplayStatus("System shutdown.");
        }
    }
}