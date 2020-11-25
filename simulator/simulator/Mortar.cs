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

        public override double DistReduction(double distance)
        {
            return distance * 0.94;
        }
    }
}
