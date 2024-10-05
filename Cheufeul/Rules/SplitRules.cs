using Cheufeul.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul.Rules
{
    public interface ISpitRule
    {
        HeapOfCards[] Apply(HeapOfCards cards);
    }

    public class Split_NearMiddleAndSwap : ISpitRule
    {
        public HeapOfCards[] Apply(HeapOfCards cards)
        {
            int randomIndex = BasicDeckOperations.RandomIndexNearMiddleOfDeck(cards.Length);

            var parts = cards.SplitAt(randomIndex);

            return parts.Reverse().ToArray();
        }
    }

    public class Split_NearMiddleSwapAndMerge : ISpitRule
    {
        public HeapOfCards[] Apply(HeapOfCards cards)
        {
            int randomIndex = BasicDeckOperations.RandomIndexNearMiddleOfDeck(cards.Length);
            
            var parts = cards.SplitAt(randomIndex);

            return [HeapOfCards.MergeRightLeft(parts)];
        }
    }
}
