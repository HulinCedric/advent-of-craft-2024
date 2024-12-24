using Delivery.Domain.Core;

namespace Delivery.Domain
{
    internal record ToyCreatedEvent(Guid Id, DateTime Date) : Event(Id, Date);
}