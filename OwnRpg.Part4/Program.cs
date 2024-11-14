using Models;

namespace OwnRpg;

class Program
{
    static void Main(string[] args)
    {
        const string saveFilePath = "hero_save.json";

        // Load hero state
        Hero hero = Hero.LoadState(saveFilePath) ?? new Hero("Archer", 100);
        Monster monster = new Monster("Goblin", 80);

        // Add items to their inventory if not loaded from save
        if (hero.Inventory.Count == 0)
        {
            hero.Inventory.Add(new WeaknessPotion());
        }
        monster.Inventory.Add(new HealthPotion());

        // Display their stats and inventory
        hero.DisplayStats();
        monster.DisplayStats();

        // Perform actions
        hero.Attack();
        hero.Cast();
        hero.UseItem(hero.Inventory.First(x => x.GetType() == typeof(WeaknessPotion)));

        monster.Attack();
        monster.Cast();
        monster.UseItem(monster.Inventory.First(x => x.GetType() == typeof(HealthPotion)));

        // Save hero state
        hero.SaveState(saveFilePath);
    }
}