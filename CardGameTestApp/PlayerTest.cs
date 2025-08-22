using CardGameApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameTestApp
{
    public class PlayerTest
    {
        [Fact]
        public void Shuffle_DiscardPile_with_DrawPile()
        {
            var deck = new List<int>();
            Player player = new Player("Player1", deck);
            player.DiscardPile.Add(10);

            Assert.Empty(player.Drawpile);
            var card= player.DrawCard();
            Assert.Equal(10,card);
            Assert.Empty(player.DiscardPile);
        }

    }
}
