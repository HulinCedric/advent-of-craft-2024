using LanguageExt;

namespace SantaChristmasList.Operations;

public class Sleigh(Dictionary<Child, Either<Failure, string>> values)
    : Dictionary<Child, Either<Failure, string>>(values);

public record Gift(string Name);

public record ManufacturedGift(string BarCode);

public record Child(string Name);

public record Failure(string Message)
{
    public static Failure New(string message) => new(message);
}