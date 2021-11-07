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
            //another way to add keys/values to our dictionary 
            //{
            //    {"Two", 2 }, {"Five", 5 }, {"Six", 6}, {"Seven", 7}, {"Eight", 8}, {"Nine", 9}, {"Ten", 10}, {"Jack", 10}, {"Queen", 10}, {"King", 10}, {"Ace", 11}
            //};

            //only the chips are created outside of the while loop, because they are not created to a default of 100 every round.
            //player and deck is created each time anew, because otherwise the players will keep their previous cards
            var playersChips = new ChipsClass();

       
            var gameOn = true;
            

            while (gameOn)
            {
                Console.WriteLine("Welcome to BlackJack!");
                Console.WriteLine($"You have {playersChips.Total} chips in your wallet");

                //create an instance of the deck class and populate it with all 52 cards.
                var ourDeck = new DeckClass(new Stack<CardClass>());

                //try to push items in randomly
                foreach (var num in suits)
                {
                    foreach (var i in ranks)
                    {
                        ourDeck.MyDeck.Push(new CardClass(num, i, values[i]));    //adding cards to stack, and cards value is updated with the values dictionary
                    }
                }

                //shuffle items in the deck
                //found this method online, don't really get it
                var shuffledDeck = ourDeck.MyDeck.OrderBy(i => Guid.NewGuid()).ToList();    //this method doesn't work because we are reutrning a list not a stack

                //create a new deckclass instance so we can populate it from the now shuffleddeck list
                var ourDeck2 = new DeckClass(new Stack<CardClass>());
                foreach (var i in shuffledDeck)
                {
                    ourDeck2.MyDeck.Push(i);
                }

                var player = new HandClass();
                var dealer = new HandClass();

                //add two cards from the deck to each hand
                player.AddCard(ourDeck2.GetCard());
                player.AddCard(ourDeck2.GetCard());
                dealer.AddCard(ourDeck2.GetCard());
                dealer.AddCard(ourDeck2.GetCard());
                //Prompt the Player for their bet
                TakeBet(playersChips);
                //Show cards (but keep one dealer card hidden)
                ShowSome(player, dealer);

                       //this while loop is meant to ask the player to play unitl he busts or wants to stand. 
                
                    HitOrStand(ourDeck2, player);
                    ShowSome(player, dealer);

                    //If player's hand exceeds 21, run player_busts() and break out of loop
                    if (player.Value > 21)
                    {
                        PlayerBusts(player, dealer, playersChips);
                    }

                    //If Player hasn't busted, play Dealer's hand until Dealer reaches 17
                     else if (player.Value <= 21)
                    {
                        //create loop that will cause dealer to hit until his hand reaches 17(soft 17)
                        while (dealer.Value < 17)
                        {
                            Hit(ourDeck2, dealer);
                        }

                        //Run different winning scenarios
                        ShowAll(player, dealer);
                        if (dealer.Value > 21)
                        {
                            DealerBusts(player, dealer, playersChips);
                        }
                        else if (dealer.Value > player.Value)
                        {
                            DealerWins(player, dealer, playersChips);
                        }
                        else if (dealer.Value < player.Value)
                        {
                            PlayerWins(player, dealer, playersChips);
                        }
                        else
                        {
                            Push(player, dealer);
                        }

                        //Inform Player of their chips total
                        Console.WriteLine($"Player's total chips are {playersChips.Total}");
                        //breal out of this round
                    }


                if (playersChips.Total <= 0)
                {
                    gameOn = false;
                    Console.WriteLine("You are out of chips and can't play again, better luck next time");
                }
                else if (playersChips.Total > 0)
                {
                    //Ask to play again
                    Console.WriteLine("Do you want to play again? y or n");
                    var response = Console.ReadLine();
                    if (response.ToLower() == "y")
                    {
                        gameOn = true;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing, hope you enjoyed");
                        gameOn = false;
                    }
                }
                

                
                
            }



        }

        //these methods might have to be included in each class respectively that we can acces them from the class because they don't exist within our program class (only in the namespace in other classes)

        public static void TakeBet(ChipsClass chip)   //this method gets the players bet
        {
            //provide an argument of an instance of a Chip class for the method

            Console.WriteLine("How many chips would you like to bet on this hand:");
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Sorry, please provide an integer");
            }
            if (userInput > chip.Total) //create chip class and check against that property if his input is higher than his balance
            {
                Console.WriteLine($"Sorry, you don't have enough chips. Current Balance {chip.Total}");
                //run the method again
                TakeBet(chip);
            }
            //if the bet is less than the total we accept the bet
            //check to see if we will have to return this value
            else
            {
                chip.Bet = userInput;
            }
        }

        //takes in the deck and players hand and updates a card to the players hand (hand passed here is player or dealer)
        //later on we will have to make a function that asks if player wants to hit and only then run this function
        public static void Hit(DeckClass deck, HandClass hand)
           {
            //get card from the deck
            var single_card = deck.GetCard();
            //add card to our hand(and adjust our counter of total hand's value)
            hand.AddCard(single_card);
            //check if new card is an ace and adjust value of hand accordingly
            hand.AceAdjuster();
        }


        //this function takes into account the deck (to hit off it) and the player (to ask him if he wants to hit off it)
        public static void HitOrStand (DeckClass deck, HandClass hand)
        {
            //finish this method as a switch statement so we check fo
            Console.WriteLine("Would you like to Hit or Stand? Enter 'h' or 's' ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "h")
            {
                Hit(deck, hand);
                //show players updated cards so he can decide if he wants to hit again
                ShowPlayer(hand);

                //call method again until player hits stand which will exit him from the method because it won't be called again
                //only if lower than 21, otherwise the method is over and player busts will be run in the main program
                if (hand.Value <= 21)
                {
                    HitOrStand(deck, hand);
                }
                else
                {
                    Console.WriteLine("You busted");
                }

            }
            else if (userInput.ToLower() == "s")
            {
                Console.WriteLine("Player stands. Dealer is playing.");
            }
            else
            {
                Console.WriteLine("Sorry, but you didn't enter h or s. Try again");
                HitOrStand(deck, hand);
            }
               
        }

            //this method is used to show only the players cards when he decides to hit again
            public static void ShowPlayer(HandClass player)
        {
            Console.WriteLine("Player's hand:");
            foreach (var cards in player.Cards)
            {
                Console.WriteLine(cards.returnCardInfo());
            }
        }

            //this function is shown in the begining
            public static void ShowSome(HandClass player, HandClass dealer)
        {
            //show only one of the dealers cards
            Console.WriteLine("\n Dealers Hand:");
            Console.WriteLine("First card hidden");
            //don't show the dealers first card at index place 0
            foreach (var card in dealer.Cards)
            {
                //show every card besides the card at index 0 (the dealers first card)
                if (card != dealer.Cards[0])
                {
                    Console.WriteLine(card.returnCardInfo());
                }
            }
                
            //show all (2) of the players cards
            Console.WriteLine("\n Player's hand: ");
            foreach (var card in player.Cards)
            {
                Console.WriteLine(card.returnCardInfo());
            }
        }

            public static void ShowAll(HandClass player, HandClass dealer)
        {
            //show all the dealers cards
            Console.WriteLine("\n Dealers Hand: ");
            foreach (var card in dealer.Cards)
            {
                Console.WriteLine(card.returnCardInfo());
            }
            //because this function is coming at the end we actually want to calculate and display value of the hand
            Console.WriteLine($"Value of dealer's hand : {dealer.Value}");
            //show all (2) of the players cards
            Console.WriteLine("\n Dealers Hand: ");
            foreach (var card in player.Cards)
            {
                Console.WriteLine(card.returnCardInfo());
            }
            Console.WriteLine($"Value of Player's hand : {player.Value}");
            
        }

                //# for all these functions we will print out what is happening and adjust the attributes accordingly
            public static void PlayerBusts (HandClass player, HandClass dealer, ChipsClass chips)
        {
            Console.WriteLine("PLAYER BUSTS");
            chips.LoseBet();
        }
        public static void PlayerWins(HandClass player, HandClass dealer, ChipsClass chips)
        {
            Console.WriteLine("PLAYER WINS");
            chips.WinBet();
        }

        public static void DealerBusts(HandClass player, HandClass dealer, ChipsClass chips)
        {
            Console.WriteLine("PLAYER WINS, DEALER BUSTED");
            chips.WinBet();
        }

        public static void DealerWins(HandClass player, HandClass dealer, ChipsClass chips)
        {
            Console.WriteLine("DEALER WINS");
            chips.LoseBet();
        }

        public static void Push(HandClass player, HandClass dealer)      //chips aren't passed in because in this scenario nothing happens to them
        {
            Console.WriteLine("Dealer and Player tie! PUSH");
        }

    }


 }




