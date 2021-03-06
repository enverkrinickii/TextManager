﻿using System.Collections.Generic;
using TextManager.Parser;

namespace TextManager.TextElements
{
    public class Sentence
    {
        private List<Word> ListOfWords = new List<Word>();
        private string _sentence;
        private readonly char[] _delimeter = { ' ', '—', '`', ',', '.', ':', ';', ':', '/', '(', ')', '[', ']', '-', '<', '>', '-', '"', '&', '\t' };

        public Sentence(string sentence)
        {
            _sentence = sentence;
            ParsSentence();
        }

        public string GetSentence()
        {
            return _sentence;
        }

        public void ParsSentence()
        {
            TextParser parser = new TextParser();
            string[] words = parser.ParsStrings(_sentence, _delimeter);
            foreach (var word in words)
            {
                if (word != "'" && word != string.Empty)
                    ListOfWords.Add(new Word(word.ToLower().Trim()));
            }
        }

        public List<Word> GetWords()
        {
            return ListOfWords;
        }

        public override string ToString()
        {
            return this._sentence;
        }


        //public List<Word> ParsSentenses()
        //{
        //    TextParser parser = new TextParser();
        //    Text text = new Text();
        //    List<Sentence> sentences = text.ParsText();
        //    foreach (var sentense in sentences)
        //    {
        //        string[] words = parser.ParsStrings(sentense, _delimeter);
        //        foreach (var item in words)
        //        {
        //            Word word = new Word(item);
        //            ListOWords.Add(word);
        //        }
        //    }
        //    return ListOWords;
        //}

    }
}
