using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models;

public record Bow(string Name, int Damage, int Range) : WeaponBase(Name, Damage)
{
    public override string ToString() => $"Bow: {Name}, Damage: {Damage}, Range: {Range}";
}
