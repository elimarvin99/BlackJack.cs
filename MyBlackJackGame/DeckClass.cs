using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackGame
{
    public class DeckClass
    {
        public DeckClass() //default constructor
        {

        }
        public DeckClass (List<CardClass> myDeck)    //custom
        {
            MyDeck = myDeck;
        }
        public List<CardClass> MyDeck { get; set; }  //property of the deck class is that it has a list of cardclass type objects.
        //with a for loop in the main program we will populate the instance with 52 different instances of the cardclass type.
    }
}
