using ControlSystem.Core;
using FluentAssertions;
using static System.Environment;

namespace ControlSystem.Tests
{
    public class TestControlSystem : IDisposable
    {
        private readonly StringWriter _dashboardDisplay;
        private readonly TextWriter _originalOutput;
        private readonly Core.System _controlSystem = new();

        public TestControlSystem()
        {
            _dashboardDisplay = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_dashboardDisplay);
        }

        [Fact]
        public void Should_start_the_sleigh_engine_and_sets_the_status_to_ON()
        {
            _controlSystem.StartSystem();

            _controlSystem.Status.Should().Be(SleighEngineStatus.On);
        }
        
        [Fact]
        public void Should_display_system_start_on_dashboard()
        {
            _controlSystem.StartSystem();
            
            _dashboardDisplay.ToString().Trim().Should().Be($"Starting the sleigh...{NewLine}System ready.");
        }

        [Fact]
        public void TestAscend()
        {
            _controlSystem.StartSystem();
            _controlSystem.Invoking(cs => cs.Ascend()).Should().NotThrow<ReindeersNeedRestException>();
            _controlSystem.Action.Should().Be(SleighAction.Flying);
            _dashboardDisplay.ToString().Trim().Should().Be($"Starting the sleigh...{NewLine}System ready.{NewLine}Ascending...");
        }
        
        [Fact]
        public void TestDescend()
        {
            _controlSystem.StartSystem();
            _controlSystem.Ascend();
            _controlSystem.Invoking(cs => cs.Descend()).Should().NotThrow<SleighNotStartedException>();
            _controlSystem.Action.Should().Be(SleighAction.Hovering);
            _dashboardDisplay.ToString().Trim().Should().Be($"Starting the sleigh...{NewLine}System ready.{NewLine}Ascending...{NewLine}Descending...");
        }

        [Fact]
        public void TestPark()
        {
            _controlSystem.StartSystem();
            _controlSystem.Invoking(cs => cs.Park()).Should().NotThrow<SleighNotStartedException>();
            _controlSystem.Action.Should().Be(SleighAction.Parked);
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _dashboardDisplay.Dispose();
        }
    }
}