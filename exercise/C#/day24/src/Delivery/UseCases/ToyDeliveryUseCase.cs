using Delivery.Domain;
using Delivery.Domain.Core;
using LanguageExt;
using static Delivery.Domain.Core.Error;
using Unit = LanguageExt.Unit;

namespace Delivery.UseCases
{
    public class ToyDeliveryUseCase(ICatalog repository)
    {
        public Either<Error, Unit> Handle(GetToyByExternalIdQuery getToyByExternalIdQuery)
        {
            var stock = repository
                .PostToy(getToyByExternalIdQuery.Id);
            switch (stock)
            {
                case null:
                    return ErrorFor(getToyByExternalIdQuery);
                default:
                    return RaisedEvent(stock).Map(_ => Unit.Default);
            }
        }

        
        private Either<Error, Toy> RaisedEvent(Toy toy)
            => toy.GetStock()
                .Let(_ => repository.Save(toy));

        private static Error ErrorFor(GetToyByExternalIdQuery getToyByExternalIdQuery)
            => AnError($"Oops we have a problem... we have not build the toy: {getToyByExternalIdQuery.Id}");
    }
}