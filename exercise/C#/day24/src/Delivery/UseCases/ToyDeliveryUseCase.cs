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
            var postToy = repository
                .PostToy(deliverToy.Id);
            if (postToy is null)
                return ErrorFor(deliverToy);
            return ReduceStock(postToy).Map(_ => Unit.Default);
        }

        
        private Either<Error, Toy> ReduceStock(Toy toy)
            => toy.GetStock()
                .Let(_ => repository.Save(toy));

        private static Error ErrorFor(DeliverToy deliverToy)
            => AnError($"Oops we have a problem... we have not build the toy: {deliverToy.Id}");
    }
}