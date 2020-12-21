using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class DepositAccount : Account
    {
        public DepositAccount(double money, double moneyLim, double percent, DateTime date) : base(money, moneyLim, percent, date) { }

        public override void CashPull(double money)
        {
            if (DateTime.Now > DateGive && money <= Money)
            {
                Money -= money;
            }
            else
                throw new Exception();//ошибку кинуть нормальную
        }

        public override void CashPush(double money)
        {
            Money = money;
        }
    }
}
