namespace Models;

public class Hero(string name, int health) : PersistentCharacter(name, health)
{
    public override void Attack()
    {
        Console.WriteLine($"{Name} attacks with a bow!");
    }

    public override void Cast()
    {
        Console.WriteLine($"{Name} casts a spell!");
    }

}
