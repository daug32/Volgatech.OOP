using System.Text.Json;
using Dictionary.Models;

namespace Dictionary.Services.Implementation;

public class TranslationSerializer : ISerializer<Translation>
{
    public string Serialize( Translation entity )
    {
        return JsonSerializer.Serialize( entity );
    }

    public Translation Deserialize( string row )
    {
        return JsonSerializer.Deserialize<Translation>( row )!;
    }
}