using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackGame
{

    public class CardClass
    {
        public CardClass() //default constructor
        {

        }
        public string suit;
        public string rank;
        //value of card is updated with the values dictionary key
        public int value;

        //create a class constructor with multiple parameters
        public CardClass(string cardsuit, string cardrank,int cardvalue)  //Dictionary<string, int>
        {
            suit = cardsuit;
            rank = cardrank;
            value = cardvalue;
        }
        public string returnCardInfo()
        {
            return $"{rank} of {suit}";
            //Console.WriteLine($"{rank} of {suit}");
        }
    }
}