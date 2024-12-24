namespace Delivery.Domain.Core
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Date { get; }
    }
}