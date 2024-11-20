using OwnRpg.Part5.Models;

namespace Models;

public abstract class Character
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public Dictionary<ItemType, List<IInventoryable>> Inventory { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
        Inventory = new Dictionary<ItemType, List<IInventoryable>>();
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{Name} - Health: {Health}");
        Console.WriteLine("Inventory:");

        foreach (var item in Inventory)
        {
            if (item.Value.Count == 0)
                continue;

            foreach (var inventoryItem in item.Value)
            {
                Console.WriteLine($"- {item.Key} {inventoryItem.Name}");
            }
        }
    }

    public virtual void Attack(Character target)
    {
        // Different ways to get the weapon from the inventory
        //var weapon = Inventory[ItemType.Weapon] != null ? Inventory[ItemType.Weapon].FirstOrDefault() as WeaponBase : null;
        var weapon = Inventory.TryGetValue(ItemType.Weapon, out var weaponList) ? weaponList.FirstOrDefault() as WeaponBase : null;

        int damage = weapon != null ? Strength * weapon.Damage : Strength;
        target.Health -= damage;

        Console.WriteLine($"{Name} hits {target.Name} for {damage} damage!");
        Console.WriteLine($"{target.Name} has {target.Health} health remaining!");
    }


    public virtual void UseItem(KeyValuePair<ItemType, IInventoryable> item)
    {
        Console.WriteLine($"{Name} uses {item.Value.Name}!");
        if (item.Value is PotionBase potion)
        {
            potion.Effect(this);
        }

        Inventory[item.Key].Remove(item.Value);
    }


    public void DropItem(KeyValuePair<ItemType, IInventoryable> item)
    {
        Console.WriteLine($"{Name} drops {item.Value.Name}!");
        Inventory[item.Key].Remove(item.Value);
    }

    // Flattern the inventory to a list of items
    public List<IInventoryable> GetItems()
    {
        return Inventory.Values.SelectMany(x => x).ToList();
    }

    // Flatten to Dictionary of inventory
    public Dictionary<ItemType, IInventoryable> GetItemsDictionary()
    {
        return Inventory.SelectMany(x => x.Value.Select(y => new { x.Key, Value = y })).ToDictionary(x => x.Key, x => x.Value);
    }
}
