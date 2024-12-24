using LanguageExt;

namespace Delivery.Domain.Core
{
    public interface IAggregate
    {
        Guid Id { get; }
        void ApplyEvent(IEvent @event);
        Seq<IEvent> GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}