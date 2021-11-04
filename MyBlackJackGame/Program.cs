using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
         var suits = new[] { "Hearts", "Diamonds", "Spades", "Clubs" };
         var ranks = new[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
         //create a dictionary of all card names with their given values, that way we can refernce the cards value throughout the game to see if < 21.
         var values = new Dictionary<string, int> { };
            values.Add("Two", 2);
            values.Add("Three", 3);
            values.Add("Four", 4);
            values.Add("Five", 5);
            values.Add("Six", 6);
            values.Add("Seven", 7);
            values.Add("Eight", 8);
            values.Add("Nine", 9);
            values.Add("Ten", 10);
            values.Add("Jack", 10);
            values.Add("Queen", 10);
            values.Add("King", 10);
            values.Add("Ace", 11);

            //create an instance of the deck class and populate it with all 52 cards.
            var ourDeck = new DeckClass(new List<CardClass>());
          
            Console.WriteLine("This instance of the Deck Class contains these cards:");
            foreach (var num in suits)
            {
                foreach (var i in ranks)
                {
                    ourDeck.MyDeck.Add(new CardClass(num, i));
                }
            }

            //shuffle items in the deck
            //found this method online, don't really get it
            var shuffledDeck = ourDeck.MyDeck.OrderBy(i => Guid.NewGuid()).ToList();
            foreach (var i in shuffledDeck)
            {
                Console.WriteLine($"{i.rank} of {i.suit}");
           
                //figure out how to write i.returnCardInfo
            }

            
        }

        //public static void TakeBet()   //this method gets the players bet
        //{
        //    //provide an argument of an instance of a Chip class for the method

        //    Console.WriteLine("How many chips would you like to bet on this hand:");
        //    int userInput;
        //    while (!int.TryParse(Console.ReadLine(), out userInput))
        //    {
        //        Console.WriteLine("Sorry, please provide an integer");
        //    }
        //    if (userInput > total) //create chip class and check against that property if his input is higher than his balance
        //    {
        //        Console.WriteLine($"Sorry, you don't have enough chips. Current Balance {//get balance from ChipsClass}");
        //    }
        //    //figure out how to return or store bet if balance is good

        //}

        //takes in the deck and players hand and updates a card to the players hand (hand passed here is player or dealer)
        //later on we will have to make a function that asks if player wants to hit and only then run this function
        //public static void Hit(//instance of the deck, //instance of players hand)
        //   {
        //    //   #get card from the deck
        //    //   single_card = deck.deal()
        //    //add card to our hand(and adjust our counter of total hand's value)
        //    //   hand.add_card(single_card)
        //    //   #check if new card is an ace and adjust value of hand accordingly
        //    //   hand.adjust_for_ace()
        //}
    

            //this function takes into account the deck (to hit off it) and the player (to ask him if he wants to hit off it)
            //public static void HitOrStand(//deck, hand)
                //{
            //global playing  # to control an upcoming while loop

            //while True:
            //    only look at first letter in lowercase of input (in case user typed 'Hit' or 'stand')
            //    x = input("Would you like to Hit or Stand? Enter 'h' or 's' ")

            //    if x[0].lower() == 'h':
            //        hit(deck, hand)  # hit() function defined above

            //    elif x[0].lower() == 's':
            //        print("Player stands. Dealer is playing.")
            //        playing = False

            //    else:
            //        print("Sorry, please try again.")
            //        continue in the while loop to ask for input again
            //        continue
            //        if one of the conditions was met than we will exit the while loop
            //    break
     }


 }




