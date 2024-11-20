using System.Runtime;

namespace Models;

public abstract class PotionBase : IInventoryable
{
    public string Name { get; private set; }

    public string ClassName => GetType().Name;

    public PotionBase(string name)
    {
        Name = name;
    }

    public abstract void Effect(Character target);
}
