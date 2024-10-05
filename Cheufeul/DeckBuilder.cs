using Cheufeul.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul
{
    internal class DeckBuilder
    {
        public Deck BuildOrderedNoDupeDeck()
        {
            return new Deck(
                new HeapOfCards("0123456789abcdefghijklmnopqrstuvwxyz")
            );
        }

        public Deck BuildMagicLikeDeck40()
        {
            return new Deck(
                new HeapOfCards("TTTTTTTTTTTTTTTTTTTTIIIIIRRRRRCCCCCCCCCC")
            );
        }
    }
}
