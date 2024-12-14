using Gifts.Domain;
using LanguageExt;

namespace Gifts.Ports;

public interface IChildrenRepository
{
    Option<Child> FindChildByName(ChildName childName);
    void AddChild(Child child);
}