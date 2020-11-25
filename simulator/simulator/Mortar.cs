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

        public override double DistanceReducer2(double distance)
        {
            return distance * 0.94;
        }
    }
}
