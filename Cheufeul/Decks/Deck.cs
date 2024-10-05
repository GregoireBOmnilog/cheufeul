using Cheufeul.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul.Decks
{
    internal class Deck
    {
        private HeapOfCards _initialContents;
        private HeapOfCards _currentContents;
        private Dictionary<char, int> _contentsCount;

        public Deck(HeapOfCards contents)
        {
            _initialContents = contents;
            _currentContents = contents;
            _contentsCount = BasicDeckOperations.CountCards(contents.ToString());
        }

        public void ApplyRulesRecursively(IMergeRule mergeRule, params ISpitRule[] rules)
        {
            List<HeapOfCards> workingHeaps = [AsHeap()];

            foreach (var rule in rules) {
                List<HeapOfCards> newHeaps = [];

                foreach (var heap in workingHeaps)
                {
                    var parts = rule.Apply(heap);

                    newHeaps.AddRange(parts);
                }

                ValidateDeckIsStillTheSame(
                    HeapOfCards.MergeLeftRight(newHeaps.ToArray())
                );

                workingHeaps = newHeaps;

                log(workingHeaps);
            }

            var finalResult = mergeRule.Merge(workingHeaps.ToArray());
            ValidateDeckIsStillTheSame(finalResult);
            _currentContents = finalResult;
        }

        private void log(List<HeapOfCards> workingHeaps)
        {
            Console.WriteLine(string.Join("---", workingHeaps.Select(s => s.ToString())));
        }

        private void ValidateDeckIsStillTheSame(HeapOfCards newHeap)
        {
            var newContentsCount = BasicDeckOperations.CountCards(newHeap.ToString());

            if (_contentsCount.Count() != newContentsCount.Count) throw new HeapsShouldBeEqualException(_currentContents, newHeap);

            try
            {
                _contentsCount.Keys.Order().SequenceEqual(newContentsCount.Keys.Order());
                _contentsCount.Values.Order().SequenceEqual(newContentsCount.Values.Order());
            }
            catch (Exception)
            {
                throw new HeapsShouldBeEqualException(_currentContents, newHeap);
            }
        }

        public HeapOfCards AsHeap()
        {
            return new HeapOfCards(_currentContents.ToString());
        }

        public override string ToString()
        {
            return $"{_currentContents.Length} cards\t{cardCountAsString()}\t{_currentContents.ToString()}";
        }

        private string cardCountAsString()
        {
            return string.Join(", ", _contentsCount.Select(pair => $"{pair.Key}: {pair.Value}"));
        }
    }

    public class HeapsShouldBeEqualException(HeapOfCards a, HeapOfCards b) : Exception($"{a} != {b}");
}
