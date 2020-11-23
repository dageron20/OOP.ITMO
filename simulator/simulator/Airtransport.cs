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
        public override double GetTime(double distance)
        {
            int reduceDistance = (int)(distance - distance * DistanceReducer / 100);
            double time = reduceDistance / Speed;
            return time;
        }
    }
}
