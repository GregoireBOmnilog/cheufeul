using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul.Decks
{
    public partial class HeapOfCards
    {
        public static HeapOfCards MergeLeftRight(params HeapOfCards[] heaps)
        {
            string acc = "";

            foreach (var heap in heaps)
            {
                acc += heap._contents;
            }

            return new HeapOfCards(acc);
        }

        public static HeapOfCards MergeRightLeft(params HeapOfCards[] heaps)
        {
            string acc = "";

            foreach (var heap in heaps.Reverse())
            {
                acc += heap._contents;
            }

            return new HeapOfCards(acc);
        }
    }
}
