namespace Models;

public class HealthPotion : PotionBase
{
    public HealthPotion() : base("Health Potion") { }

    public override void Effect()
    {
        Console.WriteLine("Health restored!");
    }
}
