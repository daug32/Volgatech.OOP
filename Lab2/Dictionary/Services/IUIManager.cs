namespace Dictionary.Services;

public interface IUIManager
{
    void Write( string str );
    void WriteLine( string str );
    string? ReadLine();
}

public class ConsoleUIManager : IUIManager
{
    public void Write( string str )
    {
        Console.Write( str );
    }

    public void WriteLine( string str )
    {
        Console.WriteLine( str );
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}