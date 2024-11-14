namespace Models;

public class Monster(string name, int health) : Character(name, health)
{
    public override void Attack()
    {
        Console.WriteLine($"{Name} attacks with claws!");
    }

    public override void Cast()
    {
        Console.WriteLine($"{Name} casts a dark spell!");
    }

}
