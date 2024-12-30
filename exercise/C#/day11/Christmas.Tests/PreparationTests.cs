using Bogus;
using FluentAssertions;
using Xunit;
using static Christmas.ToyType;

namespace Christmas.Tests
{
    public class PreparationTests
    {
        [Theory]
        [InlineData(-1, "No gifts to prepare.")]
        [InlineData(0, "No gifts to prepare.")]
        [InlineData(1, "Elves will prepare the gifts.")]
        [InlineData(49, "Elves will prepare the gifts.")]
        [InlineData(50, "Santa will prepare the gifts.")]
        public void PrepareGifts(int numberOfGifts, string expected)
            => Preparation.PrepareGifts(numberOfGifts).Should().Be(expected);

        [Theory]
        [InlineData(2, "Baby")]
        [InlineData(5, "Toddler")]
        [InlineData(12, "Child")]
        [InlineData(13, "Teen")]
        public void CategorizeGift(int age, string expectedCategory)
            => Preparation.CategorizeGift(age)
                .Should()
                .Be(expectedCategory);

        [Theory]
        [InlineData(Educational, 25, 100, true)]
        [InlineData(Fun, 30, 100, true)]
        [InlineData(Creative, 20, 100, true)]
        [InlineData(Educational, 20, 100, false)]
        [InlineData(Fun, 29, 100, false)]
        [InlineData(Creative, 15, 100, false)]
        public void EnsureToyBalance(ToyType toyType, int toysCount, int totalToys, bool expected)
            => Preparation.EnsureToyBalance(toyType, toysCount, totalToys)
                .Should()
                .Be(expected);

        [Fact]
        public void ToyBalanceIsFalseForUnExistingToyType()
            => Preparation.EnsureToyBalance(UnExistingToyType(), RandomInt(), RandomInt())
                .Should()
                .BeFalse();

        [Fact]
        public void ToyBalanceIsFalseForZeroTotalToys()
            => Preparation.EnsureToyBalance(RandomToyType(), RandomInt(), 0)
                .Should()
                .BeFalse();

        private static ToyType RandomToyType() => new Randomizer().Enum<ToyType>();
        private static ToyType UnExistingToyType() => (ToyType)new Randomizer().Int(4, int.MaxValue);
        private static int RandomInt() => new Randomizer().Int();
    }
}