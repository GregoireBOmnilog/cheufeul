using Cheufeul.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul.Rules
{
    public interface IMergeRule
    {
        HeapOfCards Merge(params HeapOfCards[] heaps);
    }

    public class Merge_RightToLeft : IMergeRule
    {
        public HeapOfCards Merge(params HeapOfCards[] heaps)
        {
            return HeapOfCards.MergeRightLeft(heaps);
        }
    }

    public class Merge_LeftToRight : IMergeRule
    {
        public HeapOfCards Merge(params HeapOfCards[] heaps)
        {
            return HeapOfCards.MergeLeftRight(heaps);
        }
    }
}
