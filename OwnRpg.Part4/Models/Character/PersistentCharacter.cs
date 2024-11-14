using System.Text.Json;

namespace Models;

public abstract class PersistentCharacter(string name, int health) : Character(name, health)
{
    public void SaveState(string filePath)
    {
        var heroState = new
        {
            Inventory = Inventory.Select(item => item.GetType().Name).ToList()
        };

        var json = JsonSerializer.Serialize(heroState);
        File.WriteAllText(filePath, json);
    }

    public static Hero? LoadState(string filePath)
    {
        if (!File.Exists(filePath))
            return null;

        var json = File.ReadAllText(filePath);
        var heroState = JsonSerializer.Deserialize<Hero?>(json);

        if (heroState == null)
            return null;

        var hero = new Hero(heroState.Name.ToString(), (int)heroState.Health);
        foreach (var itemName in heroState.Inventory)
        {
            // Assuming you have a method to create items by name
            if (itemName is null)
                continue;

            // Prevent exception
            try
            {
                var item = CreateItemByName(itemName.ToString() ?? String.Empty);
                hero.Inventory.Add(item);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Unknown item name: {itemName}");
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
    private static IInventoryable CreateItemByName(string itemName)
    {
        // Implement this method to create items by their name
        // Example:
        if (itemName == nameof(WeaknessPotion))
            return new WeaknessPotion();
        if (itemName == nameof(HealthPotion))
            return new HealthPotion();
        // Add other items as needed

        //You can also use Enum to map item names to item types
        //Example:
        //if (Enum.TryParse(itemName, out ItemType itemType))
        //{
        //    return itemType switch
        //    {
        //        ItemType.WeaknessPotion => new WeaknessPotion(),
        //        ItemType.HealthPotion => new HealthPotion(),
        //        _ => throw new ArgumentException("Unknown item name"),
        //    };
        //}

        throw new ArgumentException("Unknown item name");
    }
}
