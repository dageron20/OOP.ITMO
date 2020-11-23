using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    abstract class Airtransport : Transport
    {
        public double DistanceReducer;
        public Airtransport(string name,
                     double speed,
                     double distancereducer) : base(name, speed)
        {
            DistanceReducer = distancereducer;
        }
        public override abstract double GetTime(double distance);
    }
}
