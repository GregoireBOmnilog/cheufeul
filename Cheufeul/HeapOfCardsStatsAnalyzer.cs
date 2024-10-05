using Cheufeul.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul
{
    public record CardSpread(
        double min,
        double max,
        double avg,
        double sdev);

    internal static class HeapOfCardsStatsAnalyzer
    {
        public static CardSpread CardSpread(HeapOfCards heap, char card)
        {
            var distances = heap
                .ToString()
                .Split(card)
                .Select(x => (double)x.Length)
                .ToList();


            return new CardSpread(
                distances.Min(),
                distances.Max(),
                distances.Mean(),
                distances.StandardDeviation()
            );
        }
    }
}
