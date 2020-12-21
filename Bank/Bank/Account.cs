using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class Account
    {
        public double Money;
        public double MoneyLim;
        public double Percent;
        private static int ID = 1;
        int id;
        public Client client;
        public DateTime dateNow;
        public DateTime DateGive;
        public int DaysCounter = 0;

        public Account(double money, double moneyLim, double percent)
        {
            Money = money;
            MoneyLim = moneyLim;
            Percent = percent;
            id = ID;
            ID++;
        }
        public Account(double money, double moneyLim, double percent, DateTime date)
        {
            Money = money;
            MoneyLim = moneyLim;
            Percent = percent;
            id = ID;
            ID++;
            DateGive = date;
            dateNow = DateTime.Now;
        }

        public abstract void CashPull(double money);
        public abstract void CashPush(double money);
    }
}
