using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheufeul.Decks
{
    public partial class HeapOfCards
    {
        private string _contents;

        public HeapOfCards(string contents)
        {
            _contents = contents;
        }   

        public HeapOfCards[] SplitAt(int index)
        {
            if (index < 0 || index >= _contents.Length) throw new ArgumentOutOfRangeException("index");

            var tmp = BasicDeckOperations.SplitDeckAt(_contents, index);

            return [
                new HeapOfCards(tmp.left),
                new HeapOfCards(tmp.right)
            ];
        }

        public int Length
        {
            get { return _contents.Length; }
        }

        public override string ToString()
        {
            return _contents;
        }
    }
}
