using Newtonsoft.Json;
using OwnRpg.Part5.Models;

namespace Models;

public abstract class PersistentCharacter(string name, int health) : Character(name, health)
{


    public void SaveState(string filePath)
    {
        var heroState = new HeroState()
        {
            Name = Name,
            Health = Health,
            Inventory = Inventory.SelectMany(x => x.Value.Select(y => new InventoryFlatten()
            {
                Type = x.Key,
                ItemName = y.Name,
                ClassName = y.GetType().Name
            }))
        };

        var json = JsonConvert.SerializeObject(heroState, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }


    public static Hero? LoadState(string filePath)
    {
        if (!File.Exists(filePath))
            return null;

        var json = File.ReadAllText(filePath);
        var heroState = JsonConvert.DeserializeObject<HeroState>(json);

        if (heroState == null)
            return null;

        var hero = new Hero(heroState.Name, heroState.Health);
        foreach (var inventoryItem in heroState.Inventory)
        {
            try
            {
                var item = CreateItemByName(inventoryItem);
                if (!hero.Inventory.ContainsKey(item.Key))
                {
                    hero.Inventory.Add(item.Key, new List<IInventoryable>());
                }
                hero.Inventory[item.Key].Add(item.Value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Unknown item name: {inventoryItem.ItemName}");
            }
        }
        return hero;
    }
    /// <summary>
    /// Create an item by its name
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static KeyValuePair<ItemType, IInventoryable> CreateItemByName(InventoryFlatten flatten)
    {
        // Implement this method to create items by their name
        switch (flatten.Type)
        {
            case ItemType.Potion:
                if (flatten.ClassName == nameof(WeaknessPotion))
                {
                    return new KeyValuePair<ItemType, IInventoryable>(ItemType.Potion, new WeaknessPotion(flatten.ItemName));
                }
                if (flatten.ClassName == nameof(HealthPotion))
                {
                    return new KeyValuePair<ItemType, IInventoryable>(ItemType.Potion, new HealthPotion(flatten.ItemName));
                }
                break;
            case ItemType.Weapon:
                if (flatten.ClassName == nameof(Bow))
                {
                    return new KeyValuePair<ItemType, IInventoryable>(ItemType.Weapon, new Bow(flatten.ItemName, 5, 10));
                }
                if (flatten.ClassName == nameof(Sword))
                {
                    return new KeyValuePair<ItemType, IInventoryable>(ItemType.Weapon, new Sword(flatten.ItemName, 10, 100));
                }
                break;
        }
        throw new ArgumentException("Unknown item name");
    }

    private class HeroState
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public IEnumerable<InventoryFlatten> Inventory { get; set; }
    }

    private class InventoryFlatten
    {
        public ItemType Type { get; set; }
        public string ItemName { get; set; }
        public string ClassName { get; set; }
    }
}

