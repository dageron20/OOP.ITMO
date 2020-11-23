using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class Centaur : Landtransport
    {
        public Centaur()
            : base("Centaur", 15, 8, 2)
        { }

        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            int RestTime =(int) (distance / Speed / RestInterval);
            time += RestTime * RestDuration;
            return time;
        }
    }
}
