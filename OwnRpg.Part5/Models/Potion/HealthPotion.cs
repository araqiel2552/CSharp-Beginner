namespace Models;

public class HealthPotion : PotionBase
{
    public HealthPotion() : base("Health Potion") { }

    public override void Effect(Character character)
    {
        character.Health += 50;
        Console.WriteLine("Health restored!");
    }
}
