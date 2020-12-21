using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class CreditAccount : Account
    {
        public CreditAccount(double money, double moneyLim, double percent) : base(money, moneyLim, percent) { }

        public override void CashPull(double money)
        {
            if (client.State == Client.ClientState.Verificate && Money >= money)
            {
                Money -= money;
            }
            else
            {
                
            }
        }

        public override void CashPush(double money)
        {
            
        }
    }
}
