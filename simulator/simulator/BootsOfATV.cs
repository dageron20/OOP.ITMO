using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class BootsOfATV : Landtransport
    {
        public BootsOfATV()
            : base("Boots Of ATV", 6, 60, 10)
        { }
        public override double ResDuration(double distance)
        {
            if (times == 1)
            {
                times++;
                return 10;
            }
            else
                return 5;
        }
    }
}
