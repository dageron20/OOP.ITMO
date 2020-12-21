using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public interface IClient
    {
        void BuildName(string name);
        void BuildSurName(string surname);
        void BuildAdres(string adres);
        void BuildNumPas(int numpas);
    }
}
