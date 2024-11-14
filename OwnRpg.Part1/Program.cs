using System;

namespace RPGGame
{
    // Hero class with its own properties and methods
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Hero(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Hero Stats:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
        }
    }

    // Monster class with its own properties and methods
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Monster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Monster Stats:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
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
            Console.WriteLine();
            monster.DisplayStats();
        }
    }
}