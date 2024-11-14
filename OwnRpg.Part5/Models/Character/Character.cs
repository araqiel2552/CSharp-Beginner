namespace Models;

public abstract class Character
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int Strength { get; set; }
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

    public virtual void Attack(Character target)
    {
        var weapon = Inventory.OfType<WeaponBase>().FirstOrDefault();
        int damage = weapon != null ? Strength * weapon.Damage : Strength;
        target.Health -= damage;
        
        Console.WriteLine($"{Name} hits {target.Name} for {damage} damage!");
        Console.WriteLine($"{target.Name} has {target.Health} health remaining!");
    }

    public virtual void UseItem(IInventoryable item)
    {
        Console.WriteLine($"{Name} uses {item.Name}!");
        if (item is PotionBase potion)
        {
            // Apply the effect of the potion
            potion.Effect(this);
        }

        // Remove the item from the inventory
        Inventory.Remove(item);
    }

    public void DropItem(IInventoryable item)
    {
        Console.WriteLine($"{Name} drops {item.Name}!");
        Inventory.Remove(item);
    }
}
