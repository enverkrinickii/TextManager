using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextManager.TextElements;
using TextManager.WorkWithFile;

namespace TextManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Book.txt";
            FileManager manager = new FileManager(path);
            string text = manager.ReadFromFile();
            Text myText = new Text(text);

            List<string> listOfWords = myText.GetAllWords();
            myText.SortWords();

            Dictionary<string, int> myDictionary = myText.GetWordsWithoutCopies();

            List<string> finalList = myText.EndMethod();
            foreach (var word in finalList)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();

        }
    }
}
