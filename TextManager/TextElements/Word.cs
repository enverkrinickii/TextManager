using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.TextElements
{
    public class Word
    {
        public string _word { get; private set; }

        public Word(string word)
        {
            _word = word;
        }

        public override string ToString()
        {
            return this._word.ToString();
        }
    }
}
