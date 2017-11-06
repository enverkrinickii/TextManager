using System.Collections.Generic;

namespace TextManager.WorkWithFile
{
    interface IWorkerWithFile
    {
        string ReadFromFile();
        void WriteInFile(List<string> list, string path);
    }
}
