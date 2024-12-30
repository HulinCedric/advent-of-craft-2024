using Delivery.Domain.Core;
using LanguageExt;

namespace Delivery.Domain
{
    public interface ICatalog : IRepository<Toy>
    {
        Toy? PostToy(string toyName);
    }
}