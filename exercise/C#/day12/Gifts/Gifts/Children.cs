using LanguageExt;

namespace Gifts;

internal class Children
{
    private readonly Seq<Child> _children;

    internal Children() : this(Seq<Child>.Empty)
    {
    }

    private Children(Seq<Child> children) => _children = children;

    internal Option<Child> FindChildByName(ChildName childName) => _children.Find(child => child.IsNamed(childName));

    internal Children AddChild(Child child) => new(_children.Add(child));
}