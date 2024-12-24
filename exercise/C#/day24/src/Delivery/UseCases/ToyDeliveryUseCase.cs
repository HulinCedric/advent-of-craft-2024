using Delivery.Domain;
using Delivery.Domain.Core;
using LanguageExt;
using static Delivery.Domain.Core.Error;
using Unit = LanguageExt.Unit;

namespace Delivery.UseCases
{
    public class ToyDeliveryUseCase(IToyRepository repository)
    {
        public Either<Error, Unit> Handle(DeliverToy deliverToy)
        {
            var stock = repository
                .PostToy(deliverToy.Id);
            switch (stock)
            {
                case null:
                    return ErrorFor(deliverToy);
                default:
                    return RaisedEvent(stock).Map(_ => Unit.Default);
            }
        }

        
        private Either<Error, Toy> RaisedEvent(Toy toy)
            => toy.GetStock()
                .Let(_ => repository.Save(toy));

        private static Error ErrorFor(DeliverToy deliverToy)
            => AnError($"Oops we have a problem... we have not build the toy: {deliverToy.Id}");
    }
}