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

            string outputPath = "out.txt";

            FileManager manager = new FileManager(path);
            string text = manager.ReadFromFile();

            Console.WriteLine("Input amount of sentences on page:");
            var amount = int.Parse(Console.ReadLine());
            

            Text myText = new Text(text, amount);

            //List<string> pages = myText.GetPages(amount);

            //foreach (var page in pages)
            //{
            //    Console.WriteLine(page);
            //}

            //Console.WriteLine(pages[70]);

            var groups =  myText.GroupByFirstLetter();

            manager.WriteInFile(groups, outputPath);

            Console.WriteLine("You're file is ready. Check it");

            Console.ReadKey();

        }
    }
}
