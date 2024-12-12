using LanguageExt;

namespace Gifts;

internal class Children
{
    private Seq<Child> _children = Seq<Child>.Empty;

    internal Option<Child> FindChildByName(ChildName childName) => _children.Find(child => child.IsNamed(childName));

    internal void AddChild(Child child) => _children = _children.Add(child);
}