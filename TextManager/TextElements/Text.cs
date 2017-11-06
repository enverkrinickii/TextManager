using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextManager.Parser;
using TextManager.WorkWithFile;

namespace TextManager.TextElements
{
    public class Text
    {
        List<Sentence> Sentences = new List<Sentence>();
        public string Path { get; private set; }
        private readonly char[] Delimeter = { '.', '!', '?' };

        public Text(string path)
        {
            Path = path;
        }

        public Text()
        {
            
        }

        public List<Sentence> ParsText()
        {
            TextParser parser = new TextParser();
            FileManager manager = new FileManager();
            var text = manager.ReadFromFile(this.Path);
            string[] sentences = parser.ParsStrings(text, Delimeter);
            foreach (var item in sentences)
            {
                Sentence sentence = new Sentence(item);
                Sentences.Add(sentence);

            }
            return Sentences;
        }

        
    }
}
