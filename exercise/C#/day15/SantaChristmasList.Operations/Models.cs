using LanguageExt;
using LanguageExt.Common;

namespace SantaChristmasList.Operations;

public class Sleigh(Dictionary<Child, Either<Error, string>> values) : Dictionary<Child, Either<Error, string>>(values);

public record Gift(string Name);

public record ManufacturedGift(string BarCode);

public record Child(string Name);