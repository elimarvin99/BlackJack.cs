using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackGame
{
    public class HandClass
    {
        public HandClass() //default constructor
        {

        }

        //we are including the dictionary here so we can access it from our class, but its set to static so it's not actually a property of the class
        public static Dictionary<string, int> ValuesDic = new  Dictionary<string, int>
        {
                {"Two", 2 }, {"Three", 3}, {"Four", 4 }, {"Five", 5 }, {"Six", 6}, {"Seven", 7}, {"Eight", 8}, {"Nine", 9}, {"Ten", 10}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 11}
         };
       
        public List<CardClass> Cards = new List<CardClass>() { };
        //default value at 0 and we will add cards to each players hand as the game progresses
        public int Value = 0;
        public int Aces = 0;
        public HandClass(List<CardClass> cards, int value, int aces)            //custom constructor
        {
            Cards = cards;
            Value = value;
            Aces = aces;
        }
        //the card passed into the hand will be taken from the deal method of the Deck class
        public void AddCard (CardClass card)
        {
            Cards.Add(card);
            Value += ValuesDic[card.rank];   //figure out how to access the dictionary value from the main program without making it a property of the hand class
            if (card.rank == "Ace")
            {
                //track aces by adding them to the ace counter
                Aces += 1;
            }
        }

        //when in our code do we call this method (to apply it)? when we use the hit method we will run this method to adjust for aces so we don't bust
        public void AceAdjuster ()
        {
            while (Value > 21 && Aces > 0)
            {
                //#if hand is higher than 21 we will automatically consider the ace to be 1 and update the ace counter that we have removed an ace(because it is no longer worth 11)
                Value -= 10;
                Aces -= 1;
            }
        }
    }
}
