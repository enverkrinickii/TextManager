using System;

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
