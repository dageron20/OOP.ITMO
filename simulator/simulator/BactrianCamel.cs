using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class BactrianCamel : Landtransport
    {
        public BactrianCamel()
             : base("Bactrian Camel", 10, 30, 5)
        {  }

        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            int RestTime = (int)(distance / Speed / RestInterval);          
            time += RestDuration + RestTime * 8;
            return time;
        }
    }
}
