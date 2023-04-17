namespace Dictionary.Services.Implementation;

public class UserInterfaceHandler : IUserInterfaceHandler
{
    private readonly TextReader _inputStream;
    private readonly TextWriter _outputStream;

    public UserInterfaceHandler(
        TextReader inputStream,
        TextWriter outputStream )
    {
        _inputStream = inputStream;
        _outputStream = outputStream;
    }

    private static string ConfirmCommand => "yes";

    public string ExitCommand => "...";

    public string AskForPhrase( string language )
    {
        _outputStream.WriteLine( $"Enter {language} phrase to translate" );
        return AskForPhraseWithoutPrintingMessage();
    }

    public string AskForPhraseWithoutPrintingMessage()
    {
        return _inputStream.ReadLine()!;
    }

    public bool AskToSave()
    {
        _outputStream.WriteLine(
            $"Exit code was entered, but there are unsaved changes. Type \"{ConfirmCommand}\" to save it." );
        string command = _inputStream.ReadLine()!.ToLower();
        return command == ConfirmCommand;
    }

    public void PrintApplicationStartedMessage()
    {
        _outputStream.WriteLine( $"Dictionary application has started. Write \"{ExitCommand}\" to exit" );
    }

    public void PrintApplicationCompletedMessage()
    {
        _outputStream.WriteLine( "Application closed." );
    }

    public void PrintPhraseIgnoredMessage( string englishPhrase )
    {
        _outputStream.WriteLine( $"Phrase {englishPhrase} was ignored." );
    }

    public void PrintTranslationNotFoundMessage( string phrase, bool appendNewline )
    {
        var message = $"Unknown phrase \"{phrase}\". Enter translation to continue or an empty string to deny. ";

        if ( appendNewline )
        {
            _outputStream.WriteLine( message );
            return;
        }

        _outputStream.Write( message );
    }

    public void PrintEmptyPhraseEnteredMessage()
    {
        _outputStream.WriteLine( "Empty phrase was entered. It will not be processed." );
    }

    public void PrintTranslation( string translation )
    {
        _outputStream.WriteLine( translation );
    }
}