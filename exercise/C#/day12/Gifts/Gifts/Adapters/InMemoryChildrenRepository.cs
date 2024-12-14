using Gifts.Domain;
using Gifts.Ports;
using LanguageExt;

namespace Gifts.Adapters;

public class InMemoryChildrenRepository : IChildrenRepository
{
    private Seq<Child> _children = Seq<Child>.Empty;

    public Option<Child> FindChildByName(ChildName childName) => _children.Find(child => child.IsNamed(childName));

    public void AddChild(Child child) => _children = _children.Add(child);
}