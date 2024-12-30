using System.Globalization;
using Bogus;

namespace Children.Tests;

public static class FakerExtensions
{
    public static CultureInfo RandomCulture(this Faker faker)
    {
        var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

        return allCultures[faker.Random.Int(0, allCultures.Length - 1)];
    }
}