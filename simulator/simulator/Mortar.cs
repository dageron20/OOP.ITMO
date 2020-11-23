using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class Mortar : Airtransport
    {
        public Mortar() 
            : base("Mortar", 8, 6)
        { }
        public override double GetTime(double distance)
        {          
            int reduceDistance = (int)(distance - distance * DistanceReducer / 100);
            double time = reduceDistance / Speed;
            return time;
        }
    }
}
