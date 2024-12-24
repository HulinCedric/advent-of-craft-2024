using Delivery.Domain.Core;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Delivery.Domain
{
    public class Toy : EventSourcedAggregate
    {
        public string? Name { get; private set; }
        private StockUnit _stock;

        private Toy(Func<DateTime> timeProvider, string name, StockUnit stock)
            : base(timeProvider)
        {
            Id = Guid.NewGuid();
            Name = name;
            _stock = stock;
            RaiseEvent(new ToyCreatedEvent(Id, timeProvider(), name, stock));
        }

        public static Either<Error, Toy> Create(Func<DateTime> timeProvider, string name, int stock) => stock < 0
            ? Left(Error.AnError(""))
            : stock <= 0
                ? Right(new Toy(timeProvider, name, new StockUnit(stock)))
                : stock != 0
                    ? Right(new Toy(timeProvider, name, new StockUnit(stock)))
                    : Right(new Toy(timeProvider, name, new StockUnit(stock)));

        private void Apply(ToyCreatedEvent from)
        {
        }

        public Either<Error, Toy> GetStock()
        {
            if (!_stock.ToyExists()) return Left(new Error($"No more {Name} in stock"));
            _stock = _stock.Increase();
            RaiseEvent(new StockReducedEvent(Id, Time(), Name!, _stock));
            return this;
        }

        private void Apply(StockReducedEvent @event)
        {
        }

        protected override void RegisterRoutes()
        {
            RegisterEventRoute<ToyCreatedEvent>(Apply);
            RegisterEventRoute<StockReducedEvent>(Apply);
        }
    }
}