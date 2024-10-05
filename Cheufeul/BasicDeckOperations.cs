using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul
{
    internal class BasicDeckOperations
    {
        private static Random random = new();

        public static int RandomIndexNearMiddleOfDeck(int lengthOfDeck)
        {
            int half = lengthOfDeck/2;
            int lowerBound = half - (int)Math.Floor(0.2 * lengthOfDeck);
            int higherBound = half + (int)Math.Ceiling(0.2 * lengthOfDeck);

            if (lowerBound <= 0 || higherBound >= lengthOfDeck) throw new Exception("upsie");

            return random.Next(lowerBound, higherBound);
        }

        public static (string left, string right) SplitDeckAt(string deck, int zeroBasedIndex)
        {
            return (deck.Substring(0, zeroBasedIndex + 1), deck.Substring(zeroBasedIndex + 1));
        }

        public static string MergeDeckLeftRight((string, string) leftRight)
        {
            return leftRight.Item1 + leftRight.Item2;
        }

        public static string MergeDeckRightLeft((string, string) leftRight)
        {
            return leftRight.Item2 + leftRight.Item1;
        }

        public static Dictionary<char, int> CountCards(string deck)
        {
            var res = new Dictionary<char, int>();

            foreach (char c in deck)
            {
                if (!res.ContainsKey(c)) res[c] = 0;

                res[c]++;
            }

            return res;
        }
    }
}
