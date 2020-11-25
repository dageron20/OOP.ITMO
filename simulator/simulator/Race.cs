using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class Race<T> where T : Transport
    {
        public double Distance;
        public List<T> RaceTransports;
        
        public Race(double distance)
        {
            Distance = distance;
            RaceTransports = new List<T>();
        }
        public void AddTransport(T transport) 
        {
            RaceTransports.Add(transport);
        }
        public Transport WhoWin() 
        {
            Transport CurrentWin = default;
            double time = double.MaxValue;
            foreach(var item in RaceTransports)
            {
                if (item.GetTime(Distance) < time)
                {
                    time = item.GetTime(Distance);
                    CurrentWin = item;
                }
            }
            return CurrentWin;
        }
    }
        
}
