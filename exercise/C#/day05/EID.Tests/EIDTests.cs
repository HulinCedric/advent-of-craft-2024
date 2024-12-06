using FluentAssertions;
using Xunit;

namespace EID.Tests
{
    // Following Canon TDD here is the list of tests that should be implemented:
    // EID should be 8 characters long
    // EID should contain only digits
    // EID sex should be 1, 2 or 3
    // EID year should be between 00 and 99
    // EID serial number should be between 001 and 999
    // EID control key should be between 01 and 99
    // EID control key should be valid (complement to 97 of the number formed by the first 6 digits of the EID modulo 97)
    public class EIDTests
    {
        [Fact]
        public void A_First_Test() 
            => 43.Should()
                .Be(42, "it is universal answer");
    }
}