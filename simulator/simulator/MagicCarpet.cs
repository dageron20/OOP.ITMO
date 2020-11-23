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
        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            if((distance > 1000) && (distance < 5000))
            {
                time -= ( distance * DistanceReducer / 100 / Speed );
            }
            if ((distance > 5000) && (distance < 10000))
            {
                time -= distance * 10 / 100 / Speed;
            }
            if(distance > 10000)
            {
                time -= distance * 5 / 1000 / Speed;
            }           
            return time;
        }
    }
}
