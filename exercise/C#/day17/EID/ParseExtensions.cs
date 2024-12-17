using LanguageExt;

namespace EID;

public static class ParseExtensions
{
    public static Option<int> ToInt(this string input)
        => int.TryParse(input, out var result)
            ? result
            : Option<int>.None;
}