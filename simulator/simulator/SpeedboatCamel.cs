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

        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            int restTimes = (int)(distance / Speed / RestInterval);
            if(restTimes == 1)
            {
                time += RestDuration;
            }
            if(restTimes > 1)
            {
                time += RestDuration + 6.5 + 8 * (restTimes - 2);
            }
            return time;
        }
    }
}
