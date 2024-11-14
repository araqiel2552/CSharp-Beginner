using Models;

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
            hero.Inventory.Add(new WeaknessPotion());
            hero.Inventory.Add(new HealthPotion());
            hero.Inventory.Add(_longBow);
        }
    }

    private static Monster CreateMonster()
    {
        Monster monster = new Monster("Goblin", 80);
        monster.Inventory.Add(new HealthPotion());
        monster.Inventory.Add(_diamondSword);
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
            if (hero.Inventory.Any(x => x is PotionBase))
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
                    ChoosePotion(hero);
                    break;
                case "3":
                    DropItem(hero);
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
        for (int i = 0; i < hero.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {hero.Inventory[i].GetType().Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= hero.Inventory.Count)
        {
            hero.DropItem(hero.Inventory[itemChoice - 1]);
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    static void UsePotion<T>(Character character) where T : PotionBase
    {
        var potion = character.Inventory.FirstOrDefault(x => x.GetType() == typeof(T));
        if (potion != null)
        {
            character.UseItem(potion);
        }
        else
        {
            Console.WriteLine($"No {typeof(T).Name} available!");
        }
    }

    static void ChoosePotion(Hero hero)
    {
        Console.WriteLine("Choose a potion to use:");
        var potions = hero.Inventory.OfType<PotionBase>().ToList();
        for (int i = 0; i < potions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {potions[i].GetType().Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int potionChoice) && potionChoice > 0 && potionChoice <= potions.Count)
        {
            hero.UseItem(potions[potionChoice - 1]);
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}