using Delivery.Domain.Core;
using LanguageExt;

namespace Delivery.Domain
{
    public interface IToyRepository : IRepository<Toy>
    {
        Toy? PostToy(string toyName);
    }
}