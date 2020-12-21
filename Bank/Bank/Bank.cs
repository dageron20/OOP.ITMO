using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Bank
    {
        public List<Account> ListAccounts;
        public List<Client> ListClients;
        public List<double> PercentForDeposit;
        public List<int> IdOperation;
        public double SummForUnverClient;
        public string BankName;
        public double Comission;
        public double CreditPercent;
        public double SummForAll;
        public double PercentForDebet;
        public double DeposPercent;

        public Bank(string bankname, List<double> percentlistDep, double comission, 
                    double creditpercent, double summforunverclient, double summforall)
        {
            ListClients = new List<Client>();
            ListAccounts = new List<Account>();
            BankName = bankname;
            CreditPercent = creditpercent;
            Comission = comission;
            SummForUnverClient = summforunverclient;
            SummForAll = summforall;
            PercentForDeposit = percentlistDep;
        }
        public void AddClient(Client client)
        {
            client.SetBank(this);
            ListClients.Add(client);
        }
        public void CreateDebitAccount(Client client, double money)
        {
            Account account = new DefaultAccount(money, SummForAll, PercentForDebet);
            ListClients.Add(client);
            client.AddAccount(account);
            ListAccounts.Add(account);
        }

        public void CreateDepositAccount(Client client, double money)
        {
            if (money <= 50000)
                DeposPercent = PercentForDeposit[0];
            if (money > 50000 && money < 100000)
                DeposPercent = PercentForDeposit[1];
            if (money > 100000)
                DeposPercent = PercentForDeposit[2];

            Account account = new CreditAccount(money, SummForUnverClient, DeposPercent);
            ListClients.Add(client);
            client.AddAccount(account);
            ListAccounts.Add(account);
        } 

    }
}
