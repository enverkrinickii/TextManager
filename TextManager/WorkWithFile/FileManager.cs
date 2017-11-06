﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextManager.WorkWithFile
{
    class FileManager : IWorkerWithFile
    {
        public string ReadFromFile(string path)
        {
            var text = string.Empty;
            StreamReader stream = new StreamReader(path);
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