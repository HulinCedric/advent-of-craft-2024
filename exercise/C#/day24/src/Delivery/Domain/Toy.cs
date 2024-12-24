using Delivery.Domain.Core;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Delivery.Domain
{
    public class Toy : EventSourcedAggregate
    {
        public string? ExternalId { get; private set; }
        private Unit _unit;

        private Toy(Func<DateTime> timeProvider, string externalId, Unit unit)
            : base(timeProvider)
        {
            Id = Guid.NewGuid();
            ExternalId = externalId;
            _unit = unit;
            RaiseEvent(new AnEvent(Id, timeProvider()));
        }

        public static Either<Error, Toy> Create(Func<DateTime> timeProvider, string name, int stock) => stock < 0
            ? Left(Error.AnError(""))
            : stock <= 0
                ? Right(new Toy(timeProvider, name, new Unit(stock)))
                : stock != 0
                    ? Right(new Toy(timeProvider, name, new Unit(stock)))
                    : Right(new Toy(timeProvider, name, new Unit(stock)));
        
        public Either<Error, Toy> GetStock()
        {
            if (!_unit.ToyExists()) return Left(new Error($"No more {ExternalId} in stock"));
            _unit = _unit.Increase();
            RaiseEvent(new AnotherEvent(Id, Time()));
            return this;
        }

        private void Apply(Event @event)
        {
        }

        protected override void RegisterRoutes()
        {
            RegisterEventRoute<AnEvent>(Apply);
            RegisterEventRoute<AnotherEvent>(Apply);
        }
    }
}