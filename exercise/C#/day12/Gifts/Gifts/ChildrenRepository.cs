using LanguageExt;

namespace Gifts;

public class ChildrenRepository : IChildrenRepository
{
    private Seq<Child> _children;

    internal ChildrenRepository() : this(Seq<Child>.Empty)
    {
    }

    private ChildrenRepository(Seq<Child> children) => _children = children;

    public Option<Child> FindChildByName(ChildName childName) => _children.Find(child => child.IsNamed(childName));

    public void AddChild(Child child) => _children = _children.Add(child);
}