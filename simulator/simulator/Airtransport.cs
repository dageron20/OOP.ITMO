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
        public abstract double DistReduction(double distance);
        public override double GetTime (double distance)
        {
            return DistReduction(distance) / Speed;
        }
    }
}
