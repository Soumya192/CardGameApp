using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameApp
{
    public class Player
    {
        public String Name { get;}
        public Queue<int> Drawpile {  get; set;}
        public List<int> DiscardPile = new List<int>();
        public bool CardLeft => Drawpile.Count > 0 || DiscardPile.Count > 0;
        public int TotalCards => Drawpile.Count + DiscardPile.Count;

        public Player(String name, List<int> deck)
        {
            Name = name;
            Drawpile = new Queue<int>(deck);
        }
        public int DrawCard()
        {
            //if DrawPile is empty and Discard pile have cards shuffle Discard into DarwPile
            if (Drawpile.Count == 0 && DiscardPile.Count > 0)
            {
                Game.ShuffleDeck(DiscardPile);
                Drawpile = new Queue<int>(DiscardPile); 
                DiscardPile.Clear();
            }
            // if no cards in DrawPile return -1
            if (Drawpile.Count == 0) return -1;

            return Drawpile.Dequeue();
        }

        public void Collect(Queue<int> cards)
        {
            //Add cards from TilePile to specific Players DiscardPile
            DiscardPile.AddRange(cards);
        }
    }
}
