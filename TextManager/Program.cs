using System;
using System.Collections.Generic;
using TextManager.TextElements;
using TextManager.WorkWithFile;

namespace TextManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Book.txt";

            string outputPath = "out.txt";

            FileManager manager = new FileManager(path);
            string text = manager.ReadFromFile();

            Text myText = new Text(text);

            List<string> listOfWords = myText.GetAllWords();
            myText.SortWords();

            Dictionary<string, int> myDictionary = myText.GetWordsWithoutCopies();

            List<string> finalList = myText.EndMethod();

            manager.WriteInFile(finalList, outputPath);

            Console.WriteLine("You're file is ready. Check it");

            Console.ReadKey();

        }
    }
}
