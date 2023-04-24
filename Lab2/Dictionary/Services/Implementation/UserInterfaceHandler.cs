namespace Dictionary.Services.Implementation;

public class UserInterfaceHandler : IUserInterfaceHandler
{
    private readonly IUIManager _uiManager;
    
    public UserInterfaceHandler( IUIManager uiManager )
    {
        _uiManager = uiManager;
    }

    private static string ConfirmCommand => "yes";

    public string ExitCommand => "...";

    public string AskForPhrase( string language )
    {
        _uiManager.WriteLine( $"Enter {language} phrase to translate" );
        return AskForPhraseWithoutPrintingMessage();
    }

    public string AskForPhraseWithoutPrintingMessage()
    {
        return _uiManager.ReadLine()!;
    }

    public bool AskToSave()
    {
        _uiManager.WriteLine( 
            $"Exit code was entered, but there are unsaved changes. Type \"{ConfirmCommand}\" to save it." );
        string command = _uiManager.ReadLine()!.ToLower();
        return command == ConfirmCommand;
    }

    public void PrintApplicationStartedMessage()
    {
        _uiManager.WriteLine( $"Dictionary application has started. Write \"{ExitCommand}\" to exit" );
    }

    public void PrintApplicationCompletedMessage()
    {
        _uiManager.WriteLine( "Application closed." );
    }

    public void PrintPhraseIgnoredMessage( string englishPhrase )
    {
        _uiManager.WriteLine( $"Phrase {englishPhrase} was ignored." );
    }

    public void PrintTranslationNotFoundMessage( string phrase, bool appendNewline )
    {
        var message = $"Unknown phrase \"{phrase}\". Enter translation to continue or an empty string to deny. ";

        if ( appendNewline )
        {
            _uiManager.WriteLine( message );
            return;
        }

        _uiManager.Write( message );
    }

    public void PrintEmptyPhraseEnteredMessage()
    {
        _uiManager.WriteLine( "Empty phrase was entered. It will not be processed." );
    }

    public void PrintTranslation( string translation )
    {
        _uiManager.WriteLine( translation );
    }
}