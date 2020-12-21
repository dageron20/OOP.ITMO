using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Client
    {
        public string Name;
        public string SurName;
        public string Adress;
        public int NumPas;
        public List<Account> AccountsBank;
        public List<int> Operations;
        public Bank banK;

        public enum ClientState
        {
            Verificate, Unverificate
        }

        public ClientState State = ClientState.Unverificate; // pattern state

        /*public Client(string name, string surname)
        {
            State = ClientState.Unverificate;
            Name = name;
            SurName = surname;
        }
        public Client(string name, string surname, string adress, int numpas)
        {
            State = ClientState.Verificate;
            Name = name;
            SurName = surname;
            Adress = adress;
            NumPas = numpas;
        }*/


        /*public void ChangeVerified(string adress, int numpas)
        {
            if(State == ClientState.Verificate)
            {
                //
            }
            Adress = adress;
            NumPas = numpas;
        }*/

        /*        public void CheckReliability(Client client)
                {
                    if (Adress != null && NumPas != 0)
                    {
                        client.State = ClientState.Verificate;
                    }
                    else
                        client.State = ClientState.Unverificate;
                }*/

        public void AddAccount(Account account)
        {
            AccountsBank.Add(account);
        }
        public void SetBank(Bank bank)
        {
            banK = bank;
        }
    }
}
