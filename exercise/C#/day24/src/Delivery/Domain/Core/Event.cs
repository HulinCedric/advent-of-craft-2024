namespace Delivery.Domain.Core
{
    public record Event(Guid Id, DateTime Date) : IEvent;
}