using CardGameApp;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CardGameTestApp
{
    public class DockTest
    {
        [Fact]
        public void DeckCount_Check()
        {
            var deck = Game.CreateDeck();
            Assert.Equal(40, deck.Count);

        }

        [Fact]
        public void Deck_Shuffle_Chcek()
        {
            var deck = Game.CreateDeck();
            var originalDeck = new List<int>(deck);
            Game.ShuffleDeck(deck);

            Assert.NotEqual(originalDeck, deck);         

        }

        [Fact]
        public void CompareCards_HigherCardWin()
        {
            var deck1 = new List<int> { 1 };
            var deck2 = new List<int> { 10 };
            var player1 = new Player("Player1",deck1);
            var player2 = new Player("Player2",deck2);
            Game game = new Game(player1, player2);


            var output = new StringWriter();
            Console.SetOut(output);

            game.Play();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Assert.Contains($"{player2.Name} wins this round", output.ToString());

        }

        [Fact]
        public void tilepile()
        {
            var deck1 = new List<int> { 1,10 };
            var deck2 = new List<int> { 1, 1 };
            var player1 = new Player("Player1", deck1);
            var player2 = new Player("Player2", deck2);
            Game game = new Game(player1 , player2);
            var Output = new StringWriter();

            Console.SetOut(Output);

            game.Play();
            game.Play();
            Assert.Equal(4,player1.TotalCards);
            Assert.Equal(0,player2.TotalCards);

        }
    }
}