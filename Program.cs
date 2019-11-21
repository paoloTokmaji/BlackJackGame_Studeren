using System;
using System.Collections.Generic;
using System.Text;
using BlackJackGame_Studeren.Models;

namespace BlackJackGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                BlackJack bj = new BlackJack();
                DisplayHandsAndTotals(bj.DealerHand, bj.PlayerHand);
                while (bj.GameState != GameState.GameOver)
                {
                    if (PlayerWantsCard())
                        bj.GivePlayerAnotherCard();
                    else
                        bj.PassToDealer();
                    DisplayHandsAndTotals(bj.DealerHand, bj.PlayerHand);
                }
                Console.WriteLine("Game ends: {0}", bj.GameSummary());
            } while (PlayerWantsAnotherGame());
        }

        private static bool PlayerWantsCard()
        {
            int choice = 0;
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1. Another card ");
                Console.WriteLine("2. Pass ");
                choice = int.Parse(Console.ReadLine());
            }
            return choice == 1;
        }

        private static bool PlayerWantsAnotherGame()
        {
            char c = '?';
            while (c != 'y' && c != 'n')
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                c = char.Parse(Console.ReadLine());
            }
            return c == 'y';
        }

        private static void DisplayHandsAndTotals(Hand dealerHand, Hand playerHand)
        {
            Console.WriteLine();
            Console.WriteLine("================");
            Console.WriteLine(MapHand(dealerHand.Cards));
            Console.WriteLine("Dealer total = {0}", dealerHand.Value);
            Console.WriteLine();
            Console.WriteLine(MapHand(playerHand.Cards));
            Console.WriteLine("Player total = {0}", playerHand.Value);
            Console.WriteLine("================");
            Console.WriteLine();
        }

        private static string MapHand(IEnumerable<BlackJackCard> hand)
        {
            StringBuilder sb = new StringBuilder();
            foreach (BlackJackCard card in hand)
            {
                if (card.FaceUp)
                    sb.Append(string.Format("-{0}/{1}-", card.Suit.ToString(), card.FaceValue.ToString()));
                else
                    sb.Append("-?/?-");
            }
            return sb.ToString();
        }
    }

}

