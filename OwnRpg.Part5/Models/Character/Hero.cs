namespace Models;

public class Hero : PersistentCharacter
{
    public Hero( string name, int health) : base(name, health)
    {
        Strength = 10;
    }
    
    public void Cast()
    {
        Console.WriteLine($"{Name} casts a spell!");
    }
}
