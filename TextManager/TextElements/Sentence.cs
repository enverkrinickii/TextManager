using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextManager.Parser;
using TextManager.WorkWithFile;

namespace TextManager.TextElements
{
    public class Sentence
    {
        public List<Word> ListOWords { get; private set; }
        public string Line { get; private set; }
        private readonly char[] _delimeter = { ' ', '—', '`', ',', '.', ':', ';', ':', '/', '(', ')', '[', ']', '-', '<', '>', '-', '"', '&', '\t' };

        public Sentence(string sentence)
        {
            Line = sentence;
        }

        public List<Word> ParsSentenses()
        {
            TextParser parser = new TextParser();
            Text text = new Text();
            List<Sentence> sentences = text.ParsText();
            foreach (var sentense in sentences)
            {
                string[] words = parser.ParsStrings(sentense, _delimeter);
                foreach (var item in words)
                {
                    Word word = new Word(item);
                    ListOWords.Add(word);
                }
            }
            return ListOWords;
        }

        
    }
}
