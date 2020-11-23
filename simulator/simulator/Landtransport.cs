using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    abstract class Landtransport : Transport
    {
        public double RestInterval;
        public double RestDuration;

        public Landtransport(string name,
                             double speed,
                             double restInterval,
                             double restduration) : base(name, speed)
        {
            RestDuration = restduration;
            RestInterval = restInterval;
        }

        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            int RestTime = (int)(distance / Speed / RestInterval);
            time += RestTime * RestDuration;
            return time;
        }
    }
}
