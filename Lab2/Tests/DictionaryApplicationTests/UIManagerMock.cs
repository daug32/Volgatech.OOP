using Dictionary.Services;

namespace DictionaryTests;

public class UIManagerMock : IUIManager
{
    public List<string> InputQueue = new();
    public List<string> OutputQueue = new();

    public void Write( string str )
    {
        if ( OutputQueue.Count == 0 )
        {
            OutputQueue.Add( str );
            return;
        }

        OutputQueue[OutputQueue.Count - 1] += str;
    }

    public void WriteLine( string str )
    {
        OutputQueue.Add( str );
    }

    public string? ReadLine()
    {
        string? result = InputQueue.FirstOrDefault();

        if ( InputQueue.Count > 0 )
        {
            InputQueue.RemoveAt( 0 );
        }

        return result;
    }
}