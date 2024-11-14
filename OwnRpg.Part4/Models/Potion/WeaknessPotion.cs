namespace Models;

public class WeaknessPotion : PotionBase
{
    public WeaknessPotion() : base("Weakness Potion") { }

    public override void Effect()
    {
        Console.WriteLine("Enemy weakened!");
    }
}
