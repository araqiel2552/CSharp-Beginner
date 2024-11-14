namespace Models;

public abstract class PotionBase : IInventoryable
{
    public string Name { get; private set; }

    public PotionBase(string name)
    {
        Name = name;
    }

    public abstract void Effect();
}
