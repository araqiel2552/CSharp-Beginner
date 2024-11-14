using System;
using System.Collections.Generic;
using System.Linq;

public interface IInventoryable
{
    string Name { get; }
}

public abstract class PotionBase : IInventoryable
{
    public string Name { get; private set; }

    public PotionBase(string name)
    {
        Name = name;
    }

    public abstract void Effect();
}

public class HealthPotion : PotionBase
{
    public HealthPotion() : base("Health Potion") { }

    public override void Effect()
    {
        Console.WriteLine("Health restored!");
    }
}

public class WeaknessPotion : PotionBase
{
    public WeaknessPotion() : base("Weakness Potion") { }

    public override void Effect()
    {
        Console.WriteLine("Enemy weakened!");
    }
}

public abstract class Person
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public List<IInventoryable> Inventory { get; private set; }

    public Person(string name, int health)
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
    public abstract void UseItem(IInventoryable item);
}

public class Hero : Person
{
    public Hero(string name, int health) : base(name, health) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} attacks with a bow!");
    }

    public override void Cast()
    {
        Console.WriteLine($"{Name} casts a spell!");
    }

    public override void UseItem(IInventoryable item)
    {
        Console.WriteLine($"{Name} uses {item.Name}!");
        if (item is PotionBase potion)
        {
            potion.Effect();
        }
    }
}

public class Monster : Person
{
    public Monster(string name, int health) : base(name, health) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} attacks with claws!");
    }

    public override void Cast()
    {
        Console.WriteLine($"{Name} casts a dark spell!");
    }

    public override void UseItem(IInventoryable item)
    {
        Console.WriteLine($"{Name} uses {item.Name}!");
        if (item is PotionBase potion)
        {
            potion.Effect();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a hero and a monster
        Hero hero = new Hero("Archer", 100);
        Monster monster = new Monster("Goblin", 80);

        // Add items to their inventory
        hero.Inventory.Add(new WeaknessPotion());
        monster.Inventory.Add(new HealthPotion());

        // Display their stats and inventory
        hero.DisplayStats();
        monster.DisplayStats();

        // Perform actions
        hero.Attack();
        hero.Cast();
        hero.UseItem(hero.Inventory.First(x=>x.GetType() == typeof(WeaknessPotion)));

        monster.Attack();
        monster.Cast();
        monster.UseItem(monster.Inventory.First(x=>x.GetType() == typeof(HealthPotion)));

    }
}