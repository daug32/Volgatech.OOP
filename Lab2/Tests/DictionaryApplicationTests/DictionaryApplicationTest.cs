using Dictionary;
using Dictionary.Models;
using Dictionary.Repositories;
using Dictionary.Repositories.Implementation;
using Dictionary.Services.Implementation;
using NUnit.Framework;

namespace DictionaryTests;

public class DictionaryApplicationTest
{
    private DictionaryApplication _application = null!;
    private ITranslationRepository _translationRepository = null!;
    private IRepository<Translation> _committedTranslationsRepository = null!;

    private UIManagerMock _uiManagerMock = null!;

    [SetUp]
    public void Setup()
    {
        _uiManagerMock = new UIManagerMock();

        _committedTranslationsRepository = new MemoryRepository<Translation>();

        _translationRepository = new TranslationRepository(
            new MemoryRepository<Translation>(),
            _committedTranslationsRepository );

        _application = new DictionaryApplication(
            new UserInterfaceHandler( _uiManagerMock ),
            _translationRepository
        );
    }

    [Test]
    public void AddTranslationThatDoesntExist()
    {
        // Arrange
        var targetTranslation = "Test";
        var translation = "Тест";

        AddSetTranslationCommand( targetTranslation, translation );
        AddGetTranslationByKeywordCommand( targetTranslation );
        AddExitFromAppCommand();

        // Act
        _application.Start();
        string result = GetLastTranslation( true );

        // Assert
        Assert.That( result, Is.EqualTo( translation ) );
    }

    [Test]
    public void GetExistingTranslation()
    {
        // Arrange
        var targetKeyword = "Test";
        var expectedTranslation = "Тест";

        SetExistingTranslation( targetKeyword, expectedTranslation );
        AddGetTranslationByKeywordCommand( targetKeyword );
        AddExitFromAppCommand();

        // Act
        _application.Start();
        string result = GetLastTranslation( false );
        
        // Assert
        Assert.That( result, Is.EqualTo(expectedTranslation));
    }

    private string GetLastTranslation( bool hasNewTranslations )
    {
        if ( hasNewTranslations )
        {
            return _uiManagerMock.OutputQueue[_uiManagerMock.OutputQueue.Count - 4];
        }

        return _uiManagerMock.OutputQueue[_uiManagerMock.OutputQueue.Count - 3];
    }

    private void SetExistingTranslation( string targetKeyword, string expectedTranslation )
    {
        _committedTranslationsRepository.Add(
            new Translation
            {
                EnglishPhrase = targetKeyword,
                RussianTranslation = expectedTranslation
            } );
    }

    private void AddExitFromAppCommand()
    {
        AddCommand( "..." );
        AddCommand( "yes" );
    }

    private void AddSetTranslationCommand( string key, string value )
    {
        AddCommand( key );
        AddCommand( value );
    }

    private void AddGetTranslationByKeywordCommand( string phrase )
    {
        AddCommand( phrase );
    }

    private void AddCommand( string command )
    {
        _uiManagerMock.InputQueue.Add( command );
    }
}