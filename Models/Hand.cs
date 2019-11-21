using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame_Studeren.Models
{
    public class Hand
    {
        private readonly IList<BlackJackCard> _cards;

        public IEnumerable<BlackJackCard> Cards
        {
            get { return _cards; }
        }

        public int NrOfCards
        {
            get { return _cards.Count; }
           
        }

        public int Value
        {
            get { return CalculateTotalValue(); }
        }

        private int CalculateTotalValue()
        {
            int total = 0;
            bool ace = false;
            foreach (BlackJackCard c in Cards)
            {
                total += c.Value;
                if(c.FaceUp && c.FaceValue == FaceValue.Ace)
                {
                    ace = true;
                }
            }
            if(ace && (total + 10) <= 21)
            {
                total += 10;
            }
            return total;


        }

        public Hand()
        {
            _cards = new List<BlackJackCard>();
        }

        public void AddCard(BlackJackCard card)
        {
            _cards.Add(card);
        }

        public void TurnAllCardsFaceUp()
        {
            foreach(BlackJackCard c in _cards)
            {
                if (!c.FaceUp)
                {
                    c.TurnCard();
                }
              
            }
        }
    }
}
