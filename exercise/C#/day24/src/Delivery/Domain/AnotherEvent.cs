using Delivery.Domain.Core;

namespace Delivery.Domain
{
    public record AnotherEvent(Guid Id, DateTime Date) : Event(Id, Date);
}