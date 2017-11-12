using System.Collections.Generic;
using System.Linq;

namespace TextManager.WorkWithFile
{
    interface IWorkerWithFile
    {
        string ReadFromFile();
        void WriteInFile(IEnumerable<IGrouping<char, string>> groups, string path);
    }
}
