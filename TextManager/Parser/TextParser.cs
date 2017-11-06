using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Parser
{
    public class TextParser : IParser
    {
        public string[] ParsStrings(object line, char[] delimeter)
        {
            string[] words = line.ToString().Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}
