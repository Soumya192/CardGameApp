namespace CardGameApp
{

    class Program
    {
        static void Main()
        {
            //Create Deck of cards
            var deck = Game.CreateDeck();

            //Shuffle the deck
            Game.ShuffleDeck(deck);

            var player1 = new Player("Player 1", deck.Take(21).ToList());
            var player2 = new Player("Player 2", deck.TakeLast(21).ToList());

            Game game = new Game(player1,player2);

            //Play game if both players have card left with them
            while (player1.CardLeft && player2.CardLeft)
            {
                game.Play();
            }

            Console.WriteLine(player1.CardLeft ? $"{player1} wins this round" : $"{player2} wins this round");

        }
    }
} 