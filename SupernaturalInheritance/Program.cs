using System;

namespace MagicalInheritance
{
  class Program
  {
    static void Main(string[] args)
    {
      Storm ZulRajasStorm = new Storm("wind", false, "Zul'rajas");
      Console.WriteLine(ZulRajasStorm.Announce());
      Pupil MezilKree = new Pupil("Mezil-Kree");
      Storm MezilKreeStorm = MezilKree.CastWindStorm();
      Console.WriteLine(MezilKreeStorm.Announce());
      Mage GulDan = new Mage("Gul’dan");
      Storm GulDanRainStorm = GulDan.CastRainStorm();
      Console.WriteLine(GulDanRainStorm.Announce());
      Archmage NielasAran = new Archmage("Nielas Aran");
      Storm NielasAranRainStorm = GulDan.CastRainStorm();
      Console.WriteLine(NielasAranRainStorm.Announce());
      Storm NielasAranLightningStorm = NielasAran.CastLightningStorm();
      Console.WriteLine(NielasAranLightningStorm.Announce());
    }
  }
}