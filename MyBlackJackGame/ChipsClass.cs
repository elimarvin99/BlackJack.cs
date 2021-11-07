using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackGame
{
    public class ChipsClass
    {
        public ChipsClass()                    //default constructor
        {

        }
        public int Total = 100;
        public int Bet = 0;

        public ChipsClass (int total, int bet)                      //custom constructor in case we want to manually set the total
        {
            Total = total;
            Bet = bet;
        }

        public int WinBet()
        {
            return Total += Bet;
        }
        public int LoseBet()
        {
            return Total -= Bet;
        }
    }
    
}
