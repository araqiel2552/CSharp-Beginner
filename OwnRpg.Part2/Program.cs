using System;

public abstract class Person
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Person(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public abstract void Attack();
    public abstract void Cast();
    public abstract void UseItem(object item);

    public virtual void Fear()
    {
        Console.WriteLine($"{Name} is feeling fear!");
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{GetType().Name} Stats:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}");
    }
}

public class Hero : Person
{
    public Hero(string name, int health) : base(name, health) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} attacks with a weapon!");
    }

    public override void Cast()
    {
        Console.WriteLine($"{Name} casts a spell!");
    }

    public override void UseItem(object item)
    {
        Console.WriteLine($"{Name} uses {item}!");
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

    public override void UseItem(object item)
    {
        Console.WriteLine($"{Name} uses {item}!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a hero and a monster
        Hero hero = new Hero("Archer", 100);
        Monster monster = new Monster("Goblin", 80);

        // Display their stats
        hero.DisplayStats();
        monster.DisplayStats();

        // Perform actions
        hero.Attack();
        hero.Cast();
        hero.UseItem("Health Potion");
        hero.Fear();

        monster.Attack();
        monster.Cast();
        monster.UseItem("Poison");
        monster.Fear();
    }
}