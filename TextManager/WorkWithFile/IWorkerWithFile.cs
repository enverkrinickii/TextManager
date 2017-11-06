using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.WorkWithFile
{
    interface IWorkerWithFile
    {
        string ReadFromFile();
        void WriteInFile(List<string> list);
    }
}
