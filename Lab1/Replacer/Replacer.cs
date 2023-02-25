namespace OOP.Lab1;

public class Replacer
{
    public static string CustomReplace( string str, string search, string replace )
    {
        string result = String.Empty;
        var endIndex = 0;

        while ( endIndex > -1 )
        {
            int startIndex = str.IndexOf( search, endIndex );
            if ( startIndex == -1 )
            {
                return result + str.Substring( endIndex );
            }

            result += str.Substring( endIndex, startIndex - endIndex );
            result += replace;

            endIndex = startIndex + search.Length;
        }

        return result;
    }
    
    public static void ReplaceInFile(
        StreamReader reader,
        StreamWriter writer,
        string search,
        string replace )
    {
        while ( !reader.EndOfStream )
        {
            string line = CustomReplace( reader.ReadLine()!, search, replace );
            writer.WriteLine( line );
        }
    }
}