using Cheufeul.Rules;

namespace Cheufeul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new DeckBuilder();
            var deck = builder.BuildMagicLikeDeck40();

            Console.WriteLine(deck);
            Console.WriteLine(HeapOfCardsStatsAnalyzer.CardSpread(deck.AsHeap(), 'T'));

            deck.ApplyRulesRecursively(
                new Merge_LeftToRight(),
                new Split_NearMiddleAndSwap(),
                new Split_NearMiddleAndSwap(),
                new Split_NearMiddleAndSwap()
                
            );

            Console.WriteLine(deck);
            Console.WriteLine(HeapOfCardsStatsAnalyzer.CardSpread(deck.AsHeap(), 'T'));

            Console.ReadLine();


        }
    }
}
