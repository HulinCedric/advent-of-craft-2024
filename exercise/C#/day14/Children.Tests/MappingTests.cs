using Argon;
using static Children.Tests.X5T78Mother;

namespace Children.Tests
{
    public class MappingTests
    {
        private readonly ChildMapper _mapper;
        private readonly VerifySettings _settings;

        public MappingTests()
        {
            _mapper = new ChildMapper();
            
            _settings = new VerifySettings();
            _settings.DontScrubDateTimes();
            _settings.AddExtraSettings(s => s.DefaultValueHandling = DefaultValueHandling.Include);
        }        

        [Fact]
        public async Task Map_X5T78_To_Girl()
        {
            var child = _mapper.ToDto(Alice);

            await Verify(child, _settings);
        }

        [Fact]
        public async Task Map_X5T78_To_Child_For_A_Boy()
        {
            var child = _mapper.ToDto(Bob);

            await Verify(child, _settings);
        }
    }
}