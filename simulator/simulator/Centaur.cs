﻿using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    class Centaur : Landtransport
    {
        public Centaur()
            : base("Centaur", 15, 8, 2)
        { }
        public override double ResDuration(double distance)
        {
            return 2;
        }
    }   
}
