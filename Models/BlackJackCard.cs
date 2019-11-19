using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame_Studeren.Models
{
    public class BlackJackCard : Card
    {
       public bool FaceUp { get; set; }
        public int Value {
            get { return FaceUp ? Math.Min(10, (int) FaceValue): 0; }
        }

        public BlackJackCard(Suit suit, FaceValue faceValue ) : base(suit, faceValue)
        {
            FaceUp = false;
        }

        public void TurnCard()
        {
            FaceUp = !FaceUp;
        }
    }
}
