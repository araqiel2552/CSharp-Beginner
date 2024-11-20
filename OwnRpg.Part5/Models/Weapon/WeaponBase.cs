using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models;

public record WeaponBase(string Name, int Damage) : IInventoryable
{
    public string ClassName => GetType().Name;
}
