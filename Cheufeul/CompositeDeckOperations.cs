using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul
{
    internal static class CompositeDeckOperations
    {
        public static string CutDeckAt(string deck, int index)
        {
            var tmp = BasicDeckOperations.SplitDeckAt(deck, index);
            
            return BasicDeckOperations.MergeDeckRightLeft(tmp);
        }
    }
}
