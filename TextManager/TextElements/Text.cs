using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextManager.TextElements
{
    public class Text
    {
        private List<Sentence> ListOfSentences;
        private List<string> listOfPages;
        private int _numberOfPages;


        private string _text;
        private readonly char[] _delimeter = { '.', '!', '?' };

        public Text(string text, int numberOfPages)
        {
            _text = text;
            _numberOfPages = numberOfPages;
            ParsText();
        }

        private void ParsText()
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

        private List<string> GetAllWords()
        {
            List<string> listOfAllWords = new List<string>();
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
                    listOfAllWords.Add(item.ToString());
                }
            }
            return listOfAllWords;
        }

        //private void SortWords(List<string> list)
        //{
        //    //var sortedList = from i in list
        //    //                 orderby i
        //    //                 select i;
        //    //return sortedList.ToList();
        //    list.Sort();
        //}

        private static Dictionary<string, int> GetWordsWithoutCopies(IEnumerable<string> listOfAllWords)
        {
            Dictionary<string, int>  amountOfRepeat = new Dictionary<string, int>();
            var group = listOfAllWords.GroupBy(i => i);

            foreach (var g in group)
            {
                amountOfRepeat.Add(g.Key, g.Count());
            }
            return amountOfRepeat;
        }

        private List<string> GetNumberOfPagesWhereWordContains()
        {
            List<string> listOfAllWords = GetAllWords();
            listOfAllWords.Sort();
            GetPagesText();
            Dictionary<string, int> amountOfRepeat  = GetWordsWithoutCopies(listOfAllWords);
            List<string> endList = new List<string>();
            
            for (int i = 0; i < amountOfRepeat.Count; i++)
            {
                var item = amountOfRepeat.ElementAt(i);
                string numberOfPages = string.Empty;
                for (int j = 0; j < listOfPages.Count; j++)
                {
                    var pattern = @"\b" + Regex.Escape(item.Key) + @"\b";
                    if (Regex.IsMatch(listOfPages[j], pattern, RegexOptions.IgnoreCase))
                    {
                        numberOfPages += (j + 1) + " ";
                    }
                }
                endList.Add(item.Key.PadRight(20, '.') + item.Value.ToString().PadRight(20, '.') + numberOfPages);
            }
            return endList;
        }

        public IEnumerable<IGrouping<char, string>> GroupByFirstLetter()
        {
            List<string> endList = GetNumberOfPagesWhereWordContains();
            var wordGroups = endList.GroupBy(w => w[0]);

            return wordGroups;
        }

        private void GetPagesText()
        {
            listOfPages = new List<string>();

            int pagesCount = ListOfSentences.Count / _numberOfPages == 0 ? ListOfSentences.Count / _numberOfPages : ListOfSentences.Count / _numberOfPages + 1;

            string[] sentences = new string[ListOfSentences.Count]; 

            for (int i = 0; i < ListOfSentences.Count; i++)
            {
                sentences[i] = ListOfSentences[i].ToString().ToLower();
            }

            for (int i = 0; i < pagesCount; i++)
            {
                int startIndex = i * _numberOfPages;
                int numberOfSentences = startIndex + _numberOfPages > ListOfSentences.Count ? (ListOfSentences.Count - startIndex) : _numberOfPages;
                listOfPages.Add(string.Join(" ", sentences, startIndex, numberOfSentences));
            }
        }

    }
}
