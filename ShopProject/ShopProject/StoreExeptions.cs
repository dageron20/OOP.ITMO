using System;
using System.Collections.Generic;
using System.Text;

namespace ShopProject
{
    class StoreExeptions : System.Exception
    {
        public StoreExeptions(string message) : base(message) { }

        public class OutOfStock : StoreExeptions
        {
            public OutOfStock(string message)
                : base("There are not enough items in stock.") { }
        }

        public class IncorrectDataValue : StoreExeptions
        {
            public IncorrectDataValue(string message)
                : base("Incorrect price or quantity values were specified.") { }
        }
    }
}
