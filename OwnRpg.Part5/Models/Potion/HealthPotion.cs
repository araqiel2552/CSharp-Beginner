namespace Models;

public class HealthPotion : PotionBase
{
    public HealthPotion(string name) : base(name) { }

    public override void Effect(Character character)
    {
        character.Health += 50;
        Console.WriteLine("Health restored!");
    }
}
