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

        public override abstract double GetTime(double distance);
    }
}
