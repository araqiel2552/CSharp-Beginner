namespace Models;

public class WeaknessPotion : PotionBase
{
    public WeaknessPotion(string name) : base(name) { }

    public override void Effect(Character character)
    {
        character.Strength -= 10;
        Console.WriteLine("Enemy weakened!");
    }
}
