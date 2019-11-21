using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame_Studeren.Models
{
    public class BlackJack
    {
       

        #region Fields
        public const bool FaceDown = false;
        public const bool FaceUp = true;
        private readonly Deck _deck;
        #endregion

        #region Properties
        public Hand DealerHand { get; set; }
        public Hand PlayerHand { get; set; }
        public GameState GameState { get; set; }
        #endregion


        #region Constructors
        public BlackJack() : this(new Deck()) { }

        public BlackJack(Deck deck)
        {
            this._deck = deck;
          
            PlayerHand = new Hand();
            DealerHand = new Hand();
            Deal();
        }
        #endregion

        private void AddCardToHand(Hand hand, bool faceUp)
        {
            BlackJackCard card = _deck.Draw();
            if (faceUp)
                card.TurnCard();
            hand.AddCard(card);

        }

        private void AdjustGameState(GameState? gameState = null)
        {
            if (gameState.HasValue)
            {
                GameState = gameState.Value;
            }
            if(GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || PlayerHand.Value <= DealerHand.Value || DealerHand.Value >= 21))
            {
                GameState = GameState.GameOver;
            }
            if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
            {
                PassToDealer();
            }
        }



        public void Deal()
        {
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(PlayerHand, FaceUp);
            AddCardToHand(DealerHand, FaceUp);
            AddCardToHand(DealerHand, FaceDown);
            AdjustGameState(GameState.PlayerPlays);

        }

        public string GameSummary()
        {
            string prompt = "";
           if(GameState == GameState.GameOver)
           {
                if(PlayerHand.Value > 21)
                {
                    prompt = "Player Burned, Dealer Wins";
                }else if(DealerHand.Value > 21)
                {
                    prompt = "Dealer Burned, Player Wins";
                }else if(DealerHand.Value == PlayerHand.Value)
                {
                    prompt = "Equal, Dealer Wins";
                }else if (DealerHand.Value > PlayerHand.Value)
                {
                    prompt = "Dealer Wins";
                }else if (PlayerHand.Value > DealerHand.Value)
                {
                    prompt = "Player Wins";
                }else if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
                {
                    prompt = "BLACKJACK";
                }
           }

            return prompt;
        }

        public void GivePlayerAnotherCard()
        {
           if(GameState != GameState.PlayerPlays)
           {
                throw new InvalidOperationException("You can't draw a card now...");

           }

            AddCardToHand(PlayerHand, FaceUp);
            AdjustGameState();
        }

        public void LetDealerFinalize()
        {
            while(GameState == GameState.DealerPlays)
            {
                AddCardToHand(DealerHand, FaceUp);
                AdjustGameState();
            }
            
        }

        public void PassToDealer()
        {
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState(GameState.DealerPlays);
            LetDealerFinalize();
        }

    }
}
