using Delivery.Domain.Core;
using LanguageExt;
using static Delivery.Domain.Core.Error;

namespace Delivery.Domain
{
    public readonly struct Unit(int value)
    {
        public int Value { get; } = value;

        public static Either<Error, Unit> From(int stock)
            => stock >= 0
                ? new Unit(stock)
                : AnError("");

        public bool ToyExists() => Value > 0;
        public Unit Increase() => new(Value - 1);
    }
}