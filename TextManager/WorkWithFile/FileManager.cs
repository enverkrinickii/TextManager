using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextManager.WorkWithFile
{
    class FileManager : IWorkerWithFile
    {
        public FileManager(string path)
        {
            Path = path;
        }

        public FileManager()
        {
            
        }

        public string Path { get; private set; }

        public string ReadFromFile()
        {
            var text = string.Empty;
            StreamReader stream = new StreamReader(this.Path);
            while (!stream.EndOfStream)
            {
                text += stream.ReadLine();
            }
            return text;
        }

        public void WriteInFile(IEnumerable<IGrouping<char, string>> groups, string path)
        {
            StreamWriter stream = new StreamWriter(path);
            foreach (var group in groups)
            {
                stream.WriteLine(group.Key.ToString().ToUpper());
                foreach (var word in group)
                {
                    stream.WriteLine(word);
                }
            }
        }
    }
}
