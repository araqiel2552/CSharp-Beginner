// Storm.cs
using System;

namespace MagicalInheritance
{
  class Storm 
  {
    string Essence { get; set; }
    bool IsStrong { get; set; }
    string Caster { get; set; }

    public Storm(string essence, bool isStrong, string caster)
    { 
      Essence = essence;
      IsStrong = isStrong;
      Caster = caster;
    }
    public string Announce()
    {
      return $"{Caster} cast a {(IsStrong ? "strong" : "weak")} {Essence} storm!";
    }
  }
}
