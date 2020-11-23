using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    abstract class Transport
    {
        protected internal string Name;
        protected internal double Speed;

        public Transport(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract double GetTime(double distance);        
    }
}
