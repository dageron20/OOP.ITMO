using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class Broom : Airtransport
    {
        public Broom()
            : base("Broom", 20, 1)
        { }
        public override double DistanceReducer2(double distance)
        {
            double timeEnd = 0;
            for (int i = 1; timeEnd + 1000 < distance; i++)
                distance = (distance + 1000 * i) * 0.99;
            return timeEnd;
        }
    }
}
