using BlackJack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack

{
    internal class Balance
    {
        public double Amount { get; private set; }


        public Balance(double amount)
        {
            Amount = amount;
        }
        public void PayApostate(int playerScore, int homeScore, double betAmount)
        {
            if (playerScore > 21 || (homeScore <= 21 && playerScore < homeScore))
            {
                return;
            }
            else if (playerScore == homeScore)
            {
                Amount += betAmount;
            }
            else
            {
                Amount += betAmount * 2;
            }
        }

        public bool Withdraw(double betAmount)
        {
            if (betAmount > Amount)
            {
                return false;
            }
            Amount -= betAmount;
            return true;
        }
    }
}