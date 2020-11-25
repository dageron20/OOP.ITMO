using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    abstract class Landtransport : Transport
    {
        public double RestInterval;
        public double RestDuration;    
        public Landtransport(string name,
                             double speed,
                             double restInterval,
                             double restduration) : base(name, speed)
        {
            RestDuration = restduration;
            RestInterval = restInterval;           
        }
        public static int times = 1;
        public abstract double RestDur(double distance);
        public override double GetTime(double distance)
        {
            double time = distance / Speed;
            double timeForCounts = Math.Ceiling(time);
            double counts = timeForCounts / RestInterval;
            counts = Math.Floor(counts);
            if (distance % (Speed * RestInterval) == 0)
                counts--;
            for (int i = 0; i < counts; i++)
                time += RestDur(distance);
            return time;
        }
    }
}
