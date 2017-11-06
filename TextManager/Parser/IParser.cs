using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Parser
{
    interface IParser
    {
        string[] ParsStrings(object line, char[] delimeter);
    }
}
