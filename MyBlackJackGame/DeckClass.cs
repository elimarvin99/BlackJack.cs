using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyBlackJackGame
{
    public class DeckClass
    {
        public DeckClass() //default constructor
        {

        }
        public DeckClass (Stack<CardClass> myDeck)    //custom
        {
            MyDeck = myDeck;
        }
        public Stack<CardClass> MyDeck { get; set; }  //property of the deck class is that it has a list of cardclass type objects.
        //with a for loop in the main program we will populate the instance with 52 different instances of the cardclass type.

        //create a method to remove a card from the deck and store it in a variable
        public CardClass GetCard() //returns a cardclass object
        {

            var cardlist = new CardClass();
            cardlist = MyDeck.Pop();   //pop the first item off the stack and return it to our variable
            return cardlist; //return this cardclass object (from our stack of cardclass objects) so we can use it in our program
        }

        //create a method to return all items in the deck
        public void ReturnDeckInfo()
        {
            string deckContains = "";
            foreach (var i in MyDeck)
            {
                deckContains += "\n" + i.returnCardInfo();
            }
            Console.WriteLine("The deck has" + deckContains);
        }

        //create a method to shuffle the deck or randomly grab a card
        //because the deck is a stack of card class objects we can't shuffle it, rather in the main program we convert the stack to a list and shuffle it
        //and than we make a second stack (deck class object) and populate it with the shuffled list
        

    }
}
