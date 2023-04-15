using Dictionary.Models;
using Dictionary.Repositories;
using Dictionary.Repositories.Implementation;
using Dictionary.Services;
using Dictionary.Services.Implementation;

namespace Dictionary;

internal class Program
{
    private static readonly IUserInterfaceHandler _userInterfaceHandler = new UserInterfaceHandler(
        Console.In,
        Console.Out );

    private static readonly ITranslationRepository _translationRepository = new TranslationRepository( "" );

    internal static void Main()
    {
        _userInterfaceHandler.PrintProcessStartedMessage();

        while ( true )
        {
            string englishPhrase = _userInterfaceHandler.AskForPhrase();
            if ( englishPhrase == _userInterfaceHandler.ExitCommand )
            {
                break;
            }

            Translation? translation = _translationRepository.GetByEnglishPhrase( englishPhrase );
            if ( translation == null )
            {
                _userInterfaceHandler.PrintTranslationNotFoundMessage();

                string russianTranslation = _userInterfaceHandler.AskForPhrase();

                _translationRepository.Add(
                    new Translation
                    {
                        EnglishPhrase = englishPhrase,
                        RussianTranslations = new List<string> { russianTranslation }
                    } );

                continue;
            }

            _userInterfaceHandler.PrintTranslations( translation.RussianTranslations );
        }

        if ( _translationRepository.HasChanges )
        {
            _translationRepository.SaveChanges();
        }

        _userInterfaceHandler.PrintProcessCompletedMessage();
    }
}