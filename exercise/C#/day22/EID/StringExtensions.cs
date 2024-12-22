using LanguageExt;
using static LanguageExt.Prelude;

namespace EID
{
    public static class StringExtensions
    {
        public static Option<int> ToInt(this string potentialNumber) => parseInt(potentialNumber);
    }
}