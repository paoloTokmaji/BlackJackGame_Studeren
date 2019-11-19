using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame_Studeren.Models
{
    public class Deck
    {
        private IList<BlackJackCard> _cards;
        private static readonly Random _random = new Random();

        public Deck()
        {
            _cards = new List<BlackJackCard>();
           
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue f in Enum.GetValues(typeof(FaceValue))){
                    _cards.Add(new BlackJackCard(s, f));
                }
               
            }
        }


        public BlackJackCard Draw()
        {
           if(_cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty!");
            }
            BlackJackCard topCard = _cards[0];
            _cards.RemoveAt(0);
            return topCard;
        }

        private void Shuffle()
        {

            for (int i = 1; i < _cards.Count * 3; i++)
            {
                int randomPosition = _random.Next(0, _cards.Count);
                BlackJackCard card = _cards[randomPosition];
                _cards.RemoveAt(randomPosition);
                _cards.Add(card);
            }
        }
    }
}
