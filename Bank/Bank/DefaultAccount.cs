using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class DefaultAccount : Account
    {
        public double SummToAdd;
        public DefaultAccount(double money, double moneyLim, double percent) : base(money, moneyLim, percent) {}
        public override void CashPush(double money)
        {
            Money += money;
        }
         
        public override void CashPull(double money)
        {
            if(Money > 0)
            {
                if(client.State == Client.ClientState.Verificate)
                {
                    Money -= money;
                }
                else
                {
                    if (money <= MoneyLim)
                        Money -= money;
                    //else
                        //error сумма больше лимита
                }

            }
            ///error недостаток средств
        }
        public void UpdateMoney()
        {
            var days = (dateNow - DateGive).TotalDays;
            if (days == 0)
            {
                return;
            }
            for(int i = 0; i < days; i++)
            {
                SummToAdd += (Money + SummToAdd) * (Percent / 365) * (Percent / 365);
            }           
        }
    }
}
