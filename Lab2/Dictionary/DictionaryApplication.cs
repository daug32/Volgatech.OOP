using Dictionary.Models;
using Dictionary.Repositories;
using Dictionary.Services;

namespace Dictionary;

public class DictionaryApplication
{
    private readonly ITranslationRepository _translationRepository;
    private readonly IUserInterfaceHandler _userInterfaceHandler;

    public DictionaryApplication(
        IUserInterfaceHandler userInterfaceHandler,
        ITranslationRepository translationRepository )
    {
        _userInterfaceHandler = userInterfaceHandler;
        _translationRepository = translationRepository;
    }

    public void Start()
    {
        _userInterfaceHandler.PrintApplicationStartedMessage();

        while ( true )
        {
            if ( HandleTranslationRequest() )
            {
                break;
            }
        }

        SaveChangesIfNeed();

        _userInterfaceHandler.PrintApplicationCompletedMessage();
    }

    /// <returns>True if user wants to exit</returns>
    private bool HandleTranslationRequest()
    {
        string englishPhrase = _userInterfaceHandler.AskForPhrase( SupportedLanguages.English );
        while ( String.IsNullOrWhiteSpace( englishPhrase ) )
        {
            _userInterfaceHandler.PrintEmptyPhraseEnteredMessage();
            englishPhrase = _userInterfaceHandler.AskForPhraseWithoutPrintingMessage();
        }
        
        if ( NeedToExit( englishPhrase ) )
        {
            return true;
        }

        Translation? translation = _translationRepository.GetByEnglishPhrase( englishPhrase );
        if ( translation == null )
        {
            _userInterfaceHandler.PrintTranslationNotFoundMessage( englishPhrase, false );
            return AddTranslation( englishPhrase );
        }

        _userInterfaceHandler.PrintTranslation( translation.RussianTranslation );

        return false;
    }

    /// <returns>True if user wants to exit</returns>
    private bool AddTranslation( string englishPhrase )
    {
        string russianPhrase = _userInterfaceHandler.AskForPhrase( SupportedLanguages.Russian );
        
        if ( String.IsNullOrWhiteSpace( russianPhrase ) )
        {
            _userInterfaceHandler.PrintPhraseIgnoredMessage( englishPhrase );
            return false;
        }
        
        if ( NeedToExit( russianPhrase ) )
        {
            return true;
        }

        _translationRepository.Add(
            new Translation
            {
                EnglishPhrase = englishPhrase,
                RussianTranslation = russianPhrase
            } );

        return false;
    }

    private void SaveChangesIfNeed()
    {
        if ( _translationRepository.HasChanges && _userInterfaceHandler.AskToSave() )
        {
            _translationRepository.Commit();
        }
    }

    private bool NeedToExit( string englishPhrase )
    {
        return englishPhrase == _userInterfaceHandler.ExitCommand;
    }
}