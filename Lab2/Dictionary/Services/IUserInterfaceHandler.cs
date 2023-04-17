namespace Dictionary.Services;

public interface IUserInterfaceHandler
{
    string ExitCommand { get; }
    
    bool AskToSave();
    string AskForPhrase( string language );
    string AskForPhraseWithoutPrintingMessage();
    
    void PrintApplicationStartedMessage();
    void PrintApplicationCompletedMessage();
    
    void PrintTranslation( string translation );
    void PrintEmptyPhraseEnteredMessage();
    void PrintPhraseIgnoredMessage( string englishPhrase );
    void PrintTranslationNotFoundMessage( string phrase, bool appendNewline );
}