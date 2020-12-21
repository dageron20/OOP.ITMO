using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BuilderClient : IClient
    {
        private Client client = new Client();

        public BuilderClient()
        {
            Reset();
        }

        public void Reset()
        {
            client = new Client();
        }
        public void BuildAdres(string adres)
        {
            client.Adress = adres;
        }

        public void BuildName(string name)
        {
            client.Name = name;
        }

        public void BuildNumPas(int numpas)
        {
            client.NumPas = numpas;
        }

        public void BuildSurName(string surname)
        {
            client.SurName = surname;
        }

        public Client GetPerson()
        {
            Client result = client;
            Reset();
            result.CheckReliability(client);
            return result;           
        }
        
    }
}
