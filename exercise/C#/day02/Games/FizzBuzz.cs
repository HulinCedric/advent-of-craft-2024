using LanguageExt;

namespace Games;

public class FizzBuzz
{
    public const int Min = 1;
    public const int Max = 100;

    private readonly Dictionary<int, string> _mapping;

    public FizzBuzz(Dictionary<int, string> mapping) => _mapping = mapping;

    public Option<string> Convert(int input)
        => IsOutOfRange(input)
            ? Option<string>.None
            : ConvertSafely(input);

    private string ConvertSafely(int input)
        => _mapping
            .Where(p => Is(p.Key, input))
            .Map(kvp => kvp.Value)
            .DefaultIfEmpty(input.ToString())
            .Aggregate((accumulator, match) => accumulator + match);

    private static bool Is(int divisor, int input) => input % divisor == 0;

    private static bool IsOutOfRange(int input) => input is < Min or > Max;
}