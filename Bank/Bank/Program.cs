using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BuilderClient builder = new BuilderClient();
            builder.BuildName("Denis");
            builder.BuildSurName("Kirilyuk");
            builder.BuildAdres("Gzatskaya22");
            builder.BuildNumPas(1210);
            Client Denis = builder.GetPerson();



        }
    }
}
