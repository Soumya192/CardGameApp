using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameApp
{
    public  class Game
    {
        private Player player1;
        private Player player2;

        public Game(Player player1,Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        Queue<int> tiePile = new Queue<int>();

        public  void Play()
        {
            //getting card couunt before draw
            int p1CardCount = player1.TotalCards;
            int p2CardCount = player2.TotalCards;

            //Draw a card for each player from the drawpile
            int card1 = player1.DrawCard();
            int card2 = player2.DrawCard();

            Console.WriteLine($"{player1.Name} ({p1CardCount} cards): {card1}");
            Console.WriteLine($"{player2.Name} ({p2CardCount} cards): {card2}");

            // Add cards to tie pile
            tiePile.Enqueue(card1);
            tiePile.Enqueue(card2);

            //if card1 is hugher then card2 Player1 is winner
            if (card1 > card2)
            {
                Console.WriteLine($"{player1.Name} wins this round");
                player1.Collect(tiePile);
                tiePile.Clear();
            }
            //if card2 is greater than card1 player2 is winner
            else if (card2 > card1)
            {
                Console.WriteLine($"{player2.Name} wins this round");
                player2.Collect(tiePile);
                tiePile.Clear();
            }
            //if both cards have same value its a tie
            else
            {
                Console.WriteLine("No winner in this round (tie)");
                // keep tiePile until next round decides the winner
            }

            Console.WriteLine();
        }
       
        public static List<int> CreateDeck()
        {
            var deck = new List<int>();
            for(var i=1; i<=10; i++)
            {
                for(var j=0; j<4 ; j++)
                {
                     deck.Add(i);
                }
            }
            return deck;
        }
        public static void ShuffleDeck(List<int> deck)
        {
            var n=deck.Count;
            Random rand = new Random();
            for (int i = 0; i < n; i++) {
                var j = rand.Next(i + 1);
                (deck[i], deck[j]) = (deck[j], deck[i]);
            }
        }
    }
}
