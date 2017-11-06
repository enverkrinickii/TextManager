using System.Collections.Generic;
using System.IO;

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

        public void WriteInFile(List<string> list, string path)
        {
            StreamWriter stream = new StreamWriter(path);
            foreach (var item in list)
            {
                stream.WriteLine(item);
            }
        }
    }
}
