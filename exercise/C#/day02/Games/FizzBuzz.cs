using LanguageExt;

namespace Games;

public class FizzBuzz(Configuration configuration)
{
    public Option<string> Convert(int input)
        => IsOutOfRange(input)
            ? Option<string>.None
            : ConvertSafely(input);

    private string ConvertSafely(int input)
        => configuration.Rules
            .Where(p => Is(p.Key, input))
            .Map(kvp => kvp.Value)
            .DefaultIfEmpty(input.ToString())
            .Aggregate((acc, representation) => acc + representation);

    private static bool Is(int divisor, int input) => input % divisor == 0;

    private bool IsOutOfRange(int input) => input < configuration.Min || input > configuration.Max;
}