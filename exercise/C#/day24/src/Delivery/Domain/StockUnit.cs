using Delivery.Domain.Core;
using LanguageExt;
using static Delivery.Domain.Core.Error;

namespace Delivery.Domain
{
    public readonly struct StockUnit(int value)
    {
        public int Value { get; } = value;

        public static Either<Error, StockUnit> From(int stock)
            => stock >= 0
                ? new StockUnit(stock)
                : AnError("");

        public bool ToyExists() => Value > 0;
        public StockUnit Increase() => new(Value - 1);
    }
}