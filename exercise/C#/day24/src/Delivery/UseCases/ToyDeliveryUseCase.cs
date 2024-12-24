using Delivery.Domain;
using Delivery.Domain.Core;
using LanguageExt;
using static Delivery.Domain.Core.Error;

namespace Delivery.UseCases
{
    public class ToyDeliveryUseCase(IToyRepository repository)
    {
        public Either<Error, Unit> Handle(DeliverToy deliverToy)
        {
            var stock = repository
                .PostToy(deliverToy.Id);
            if (stock is null)
                return ErrorFor(deliverToy);
            return RaisedEvent(stock).Map(_ => Unit.Default);
        }

        
        private Either<Error, Toy> RaisedEvent(Toy toy)
            => toy.GetStock()
                .Let(_ => repository.Save(toy));

        private static Error ErrorFor(DeliverToy deliverToy)
            => AnError($"Oops we have a problem... we have not build the toy: {deliverToy.Id}");
    }
}