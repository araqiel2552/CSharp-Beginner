using Models;
using OwnRpg.Part5.Models;

namespace OwnRpg;

class Program
{
    private static readonly Bow _longBow = new Bow("Longbow", 5, 10);
    private static readonly Sword _diamondSword = new Sword("Diamond Sword", 10, 100);
    private const string saveFilePath = "hero_save.json";

    static void Main(string[] args)
    {
        Hero hero = LoadOrCreateHero(saveFilePath);
        InitializeHeroInventory(hero);
        hero.SaveState(saveFilePath);

        Monster monster = CreateMonster();

        DisplayStats(hero, monster);

        CombatLoop(hero, monster);
    }

    private static Hero LoadOrCreateHero(string saveFilePath)
    {
        Hero? hero = PersistentCharacter.LoadState(saveFilePath);
        hero ??= CreateNewHero();
        return hero;
    }

    private static Hero CreateNewHero()
    {
        string? heroName = null;
        while (string.IsNullOrWhiteSpace(heroName))
        {
            Console.Write("Enter your hero's name: ");
            heroName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(heroName))
            {
                Console.WriteLine("Name cannot be empty!");
            }
        }
        return new Hero(heroName, 100);
    }

    private static void InitializeHeroInventory(Hero hero)
    {
        if (hero.Inventory.Count == 0)
        {
            hero.Inventory.Add(ItemType.Potion, new List<IInventoryable> { new HealthPotion("Health Potion"), new WeaknessPotion("Weakness Potion") });
            hero.Inventory.Add(ItemType.Weapon, new List<IInventoryable> { _longBow });
        }
    }

    private static Monster CreateMonster()
    {
        Monster monster = new Monster("Goblin", 80);

        monster.Inventory.Add(ItemType.Potion, [new HealthPotion("Health Potion")]); // Collection initialization simplified
        monster.Inventory.Add(ItemType.Weapon, [_diamondSword]); // Collection initialization simplified

        return monster;
    }

    private static void DisplayStats(Hero hero, Monster monster)
    {
        hero.DisplayStats();
        monster.DisplayStats();
    }

    private static void DisplayMenuChoice(Hero hero)
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1. Attack");

        if (hero.Inventory.Count > 0)
        {
            Console.WriteLine("2. Drop item");
            if (hero.Inventory.ContainsKey(ItemType.Potion))
                Console.WriteLine("3. Use Potion");
        }
    }


    private static void CombatLoop(Hero hero, Monster monster)
    {
        while (hero.Health > 0 && monster.Health > 0)
        {
            DisplayMenuChoice(hero);
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    hero.Attack(monster);
                    break;
                case "2":
                    DropItem(hero);
                    break;
                case "3":
                    ChoosePotion(hero);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            // Monster's turn
            if (monster.Health > 0)
            {
                Random rand = new();
                if (rand.Next(2) == 0)
                {
                    monster.Attack(hero);
                }
                else
                {
                    UsePotion<HealthPotion>(monster);
                }
            }

            DisplayStats(hero, monster);

            // Save hero state
            hero.SaveState(saveFilePath);
        }

        Console.WriteLine(hero.Health > 0 ? "You defeated the monster!" : "You were defeated by the monster!");
    }

    private static void DropItem(Hero hero)
    {
        Console.WriteLine("Choose an item to drop:");

        var inventory = hero.GetItems();
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= hero.Inventory.Count)
        {
            foreach (var itemType in hero.Inventory.Keys)
            {
                if (itemChoice <= hero.Inventory[itemType].Count)
                {
                    hero.DropItem(new KeyValuePair<ItemType, IInventoryable>(itemType, hero.Inventory[itemType][itemChoice - 1]));
                    break;
                }
                itemChoice -= hero.Inventory[itemType].Count;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    static void UsePotion<T>(Character character) where T : PotionBase
    {
        var potion = character.Inventory[ItemType.Potion].OfType<T>().FirstOrDefault();
        if (potion != null)
        {
            character.UseItem(new KeyValuePair<ItemType, IInventoryable>(ItemType.Potion, potion));
        }
        else
        {
            Console.WriteLine($"No {typeof(T).Name} available!");
        }
    }

    static void ChoosePotion(Hero hero)
    {
        Console.WriteLine("Choose a potion to use:");
        var potions = hero.Inventory[ItemType.Potion].OfType<PotionBase>().ToList();
        for (int i = 0; i < potions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {potions[i].GetType().Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int potionChoice) && potionChoice > 0 && potionChoice <= potions.Count)
        {
            hero.UseItem(new KeyValuePair<ItemType, IInventoryable>(ItemType.Potion, potions[potionChoice - 1]));
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}