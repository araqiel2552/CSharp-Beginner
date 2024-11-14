using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models;

public record Sword(string Name, int Damage, int Durability) : WeaponBase(Name, Damage);
