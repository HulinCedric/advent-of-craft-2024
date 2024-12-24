using Delivery.Domain.Core;

namespace Delivery.Domain
{
    internal record AnEvent(Guid Id, DateTime Date) : Event(Id, Date);
}