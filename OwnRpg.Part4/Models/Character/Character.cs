namespace Models;

public abstract class Character
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public List<IInventoryable> Inventory { get; private set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
        Inventory = new List<IInventoryable>();
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{Name} - Health: {Health}");
        Console.WriteLine("Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item.Name}");
        }
    }

    public abstract void Attack();
    public abstract void Cast();

    public virtual void UseItem(IInventoryable item)
    {
        Console.WriteLine($"{Name} uses {item.Name}!");
        if (item is PotionBase potion)
        {
            // Apply the effect of the potion
            potion.Effect();
        }

        // Remove the item from the inventory
        Inventory.Remove(item);
    }
}
