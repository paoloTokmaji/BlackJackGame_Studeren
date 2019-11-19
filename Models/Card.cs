
using BlackJackGame_Studeren.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame_Studeren.Models
{
    public class Card
    {
       public FaceValue FaceValue { get; set; }
       public Suit Suit { get; set; }

        public Card(Suit suit, FaceValue faceValue)
        {
            FaceValue = faceValue;
            Suit = suit;
        }
    }
}
