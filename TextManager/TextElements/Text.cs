using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextManager.Parser;
using TextManager.WorkWithFile;

namespace TextManager.TextElements
{
    public class Text
    {
        private List<Sentence> ListOfSentences;
        private List<string> ListOfAllWords;
        private Dictionary<string, int> amountOfRepeat;
        private string _text;
        private readonly char[] _delimeter = { '.', '!', '?' };

        public Text(string text)
        {
            _text = text;
            ParsText();
        }

        public void ParsText()
        {
            ListOfSentences = new List<Sentence>();
            string[] sents = _text.Split(_delimeter , StringSplitOptions.RemoveEmptyEntries);
            foreach (var sent in sents)
            {
                ListOfSentences.Add(new Sentence(sent));
            }
        }

        public List<Sentence> GetSentences()
        {
            return ListOfSentences;
        }

        public List<string> GetAllWords()
        {
            ListOfAllWords = new List<string>();
            List<List<Word>> listOfWords = new List<List<Word>>();
            foreach (var sentence in ListOfSentences)
            {
                Sentence sent = new Sentence(sentence.ToString());
                List<Word> words = sent.GetWords();
                listOfWords.Add(words);
            }

            foreach (var word in listOfWords)
            {
                foreach (var item in word)
                {
                    ListOfAllWords.Add(item.ToString());
                }
            }
            return ListOfAllWords;
        }

        public void SortWords()
        {
            ListOfAllWords.Sort();
        }

        public Dictionary<string, int> GetWordsWithoutCopies()
        {
            amountOfRepeat = new Dictionary<string, int>();
            var group = ListOfAllWords.GroupBy(i => i);

            foreach (var g in group)
            {
                amountOfRepeat.Add(g.Key, g.Count());
            }
            return amountOfRepeat;
        }

        public List<string> EndMethod()
        {
            List<string> endList = new List<string>();
            for (int i = 0; i < amountOfRepeat.Count; i++)
            {
                var item = amountOfRepeat.ElementAt(i);
                string numbersOfSentences = string.Empty;
                for (int j = 0; j < ListOfSentences.Count; j++)
                {
                    var pattern = @"\b" + Regex.Escape(item.Key) + @"\b";
                    if (Regex.IsMatch(ListOfSentences[j].ToString(), pattern, RegexOptions.IgnoreCase))
                    {
                        numbersOfSentences += (j + 1) + " ";
                    }
                }
                endList.Add(item.Key.PadRight(20, '.') + item.Value.ToString().PadRight(20, '.') + numbersOfSentences);
            }
            return endList;
        }

    }
}
