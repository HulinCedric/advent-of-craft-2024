using Delivery.Domain.Core;

namespace Delivery.Domain
{
    public record StockReducedEvent(Guid Id, DateTime Date) : Event(Id, Date);
}