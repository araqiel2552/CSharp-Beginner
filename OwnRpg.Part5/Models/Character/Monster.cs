namespace Models;

public class Monster : Character
{
    public Monster(string name, int health) : base(name, health)
    {
        Strength = 5;
    }
}
