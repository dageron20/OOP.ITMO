using System;

namespace simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            BactrianCamel bactrian = new BactrianCamel();
            BootsOfATV boots = new BootsOfATV();
            Broom broom = new Broom();
            Centaur centaur = new Centaur();
            MagicCarpet magiccarpet = new MagicCarpet();
            Mortar mortar = new Mortar();
            SpeedboatCamel speedboat = new SpeedboatCamel();

            /*Console.WriteLine(bactrian.GetTime(1000));
            Console.WriteLine(speedboat.GetTime(1000));
            Console.WriteLine(centaur.GetTime(1000));
            Console.WriteLine(boots.GetTime(1000));
            Console.WriteLine(magiccarpet.GetTime(1000));
            Console.WriteLine(mortar.GetTime(1000));
            Console.WriteLine(broom.GetTime(1000));*/

            Console.WriteLine(centaur.GetTime(120)); // 8
            Console.WriteLine(centaur.GetTime(121)); // 10.0666
            Console.WriteLine(centaur.GetTime(240)); // 18
            Console.WriteLine(centaur.GetTime(241)); // 20.0666
            Console.WriteLine(boots.GetTime(721));
            /*Race<Landtransport> Formula1 = new Race<Landtransport>(1000);
            Formula1.RaceTransports.Add(speedboat);
            Formula1.RaceTransports.Add(bactrian);
            Formula1.RaceTransports.Add(boots);
            Formula1.RaceTransports.Add(centaur);
            Console.WriteLine(Formula1.WhoWin().Name + " --- " + " Win LandTransport ");

            Race<Airtransport> AntiFormula2 = new Race<Airtransport>(1000);
            AntiFormula2.RaceTransports.Add(magiccarpet);
            AntiFormula2.RaceTransports.Add(mortar);
            AntiFormula2.RaceTransports.Add(broom);
            Console.WriteLine(AntiFormula2.WhoWin().Name + " --- " + " Win AirTransport ");

            Race<Transport> CheatingFormula = new Race<Transport>(1000);
            CheatingFormula.RaceTransports.Add(speedboat);
            CheatingFormula.RaceTransports.Add(bactrian);
            CheatingFormula.RaceTransports.Add(boots);
            CheatingFormula.RaceTransports.Add(centaur);
            CheatingFormula.RaceTransports.Add(magiccarpet);
            CheatingFormula.RaceTransports.Add(mortar);
            CheatingFormula.RaceTransports.Add(broom);
            Console.WriteLine(CheatingFormula.WhoWin().Name + " --- " + " Win AirLandTransport ");*/
        }
    }
}
