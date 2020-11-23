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
        public override double GetTime(double distance)
        {
            int reduceTimes = (int)(distance / 1000);
            for(int i = 1; i < reduceTimes; i++)
            {
                distance -= distance / 100;
            }
            double time = distance / Speed;
            return time;
        }
    }
}
