using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void WriteInFile(List<string> list)
        {
            throw new NotImplementedException();
        }
    }
}
