using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class MagicCarpet : Airtransport
    {
        public MagicCarpet() 
            : base("Magic carpet", 10, 3)
        { }
        public override double DistanceReducer2(double distance)
        {
            if ((distance >= 1000) && (distance < 5000))
                return distance;
            if ((distance >= 5000) && (distance < 10000))
                return distance * 0.97;
            if (distance >= 10000)
                return distance * 0.95;
            return 0;
        }
    }
}
