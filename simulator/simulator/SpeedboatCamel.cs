using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class SpeedboatCamel : Landtransport
    {

        public SpeedboatCamel()
            : base("SpeedBoat Camel", 40, 10, 5)
        { }
        public override double RestDur(double distance)
        {
            int times = 1;
            if (times == 1)
            {
                times++;
                return 5;
            }
            if (times == 2)
            {
                times++;
                return 6.5;
            }
            else
                return 8;
        }
    }
}
