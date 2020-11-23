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
        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            int restTimes = (int)(distance / Speed / RestInterval);           
            time += RestDuration + restTimes * 5;
            return time;
        }
    }
}
