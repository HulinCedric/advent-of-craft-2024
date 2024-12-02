using LanguageExt;

namespace Games;

public class FizzBuzz(Dictionary<int, string> mapping, int min, int max)
{
    public Option<string> Convert(int input)
        => IsOutOfRange(input)
            ? Option<string>.None
            : ConvertSafely(input);

    private string ConvertSafely(int input)
        => mapping
            .Where(p => Is(p.Key, input))
            .Map(kvp => kvp.Value)
            .DefaultIfEmpty(input.ToString())
            .Aggregate((accumulator, match) => accumulator + match);

    private static bool Is(int divisor, int input) => input % divisor == 0;

    private bool IsOutOfRange(int input) => input < min || input > max;
}