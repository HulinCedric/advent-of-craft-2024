using FluentAssertions;
using FluentAssertions.LanguageExt;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Games.Tests;

public class FizzBuzzTests
{
    private static readonly string[] FizzBuzzStrings =
        ["Fizz", "Buzz", "Whizz", "FizzBuzz", "FizzWhizz", "BuzzWhizz", "FizzBuzzWhizz"];

    private readonly FizzBuzz _fizzBuzz = new(
        new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" },
            { 7, "Whizz" }
        });

    [Theory]
    [InlineData(1, "1")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    [InlineData(3, "Fizz")]
    [InlineData(66, "Fizz")]
    [InlineData(99, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(50, "Buzz")]
    [InlineData(85, "Buzz")]
    [InlineData(7, "Whizz")]
    [InlineData(14, "Whizz")]
    [InlineData(28, "Whizz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    [InlineData(21, "FizzWhizz")]
    [InlineData(42, "FizzWhizz")]
    [InlineData(63, "FizzWhizz")]
    [InlineData(35, "BuzzWhizz")]
    [InlineData(70, "BuzzWhizz")]
    [InlineData(140, "BuzzWhizz", Skip = "Over the limit")]
    [InlineData(105, "FizzBuzzWhizz", Skip = "Over the limit")]
    [InlineData(210, "FizzBuzzWhizz", Skip = "Over the limit")]
    [InlineData(420, "FizzBuzzWhizz", Skip = "Over the limit")]
    public void Returns_Number_Representation(int input, string expectedResult)
        => _fizzBuzz.Convert(input)
            .Should()
            .BeSome(x => x.Should().Be(expectedResult));

    [Property]
    public Property Parse_Return_Valid_String_For_Numbers_Between_1_And_100()
        => Prop.ForAll(
            ValidInput(),
            IsConvertValid);

    private static Arbitrary<int> ValidInput() => Gen.Choose(FizzBuzz.Min, FizzBuzz.Max).ToArbitrary();

    private bool IsConvertValid(int x) => _fizzBuzz.Convert(x).Exists(s => ValidStringsFor(x).Contains(s));

    private static IEnumerable<string> ValidStringsFor(int x) => FizzBuzzStrings.Append(x.ToString());

    [Property]
    public Property ParseFailForNumbersOutOfRange()
        => Prop.ForAll(
            InvalidInput(),
            x => _fizzBuzz.Convert(x).IsNone);

    private static Arbitrary<int> InvalidInput()
        => Gen.Choose(-10_000, 10_000)
            .ToArbitrary()
            .Filter(x => x is < FizzBuzz.Min or > FizzBuzz.Max);
}