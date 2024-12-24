namespace Delivery.Domain.Core
{
    public interface IRepository<TAggregate>
        where TAggregate : EventSourcedAggregate
    {
        void Save(TAggregate aggregate);
    }
}