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
        public override double ResDuration(double distance)
        {
            if (times == 1)
            {
                times++;
                return 5;
            }
            else
                return 8;               
        }
    }
}
