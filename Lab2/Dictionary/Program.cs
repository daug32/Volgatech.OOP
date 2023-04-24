using Dictionary.Models;
using Dictionary.Repositories.Implementation;
using Dictionary.Services;
using Dictionary.Services.Implementation;

namespace Dictionary;

public class Program
{
    internal static void Main()
    {
        BuildApplication()
            .Start();
    }

    private static DictionaryApplication BuildApplication()
    {
        IUserInterfaceHandler userInterfaceHandler = new UserInterfaceHandler( new ConsoleUIManager() );

        var translationFileDatabase = "D:/Development/Projects/OOP/Lab2/Dictionary/translations.txt";

        var memoryRepository = new MemoryRepository<Translation>();
        var fileRepository = new FileRepository<Translation>(
            translationFileDatabase,
            new TranslationSerializer() );

        var translationRepository = new TranslationRepository(
            memoryRepository,
            fileRepository );

        return new DictionaryApplication(
            userInterfaceHandler,
            translationRepository );
    }
}