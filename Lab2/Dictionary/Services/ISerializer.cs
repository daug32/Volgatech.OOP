namespace Dictionary.Services;

public interface ISerializer<T>
    where T : notnull
{
    string Serialize( T entity );
    T Deserialize( string row );
}