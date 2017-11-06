namespace TextManager.Parser
{
    interface IParser
    {
        string[] ParsStrings(object line, char[] delimeter);
    }
}
