namespace Models;

public class WeaknessPotion : PotionBase
{
    public WeaknessPotion() : base("Weakness Potion") { }

    public override void Effect(Character character)
    {
        character.Strength -= 10;
        Console.WriteLine("Enemy weakened!");
    }
}
