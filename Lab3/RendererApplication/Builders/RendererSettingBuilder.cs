using RendererApplication.Models;

namespace RendererApplication.Builders;

public class RendererSettingBuilder
{
    public static RendererSettings Build( string[] args )
    {
        var settings = new RendererSettings();
        if ( args.Length > 0 )
        {
            settings.FilePath = Path.GetFullPath( args[0] );
        }

        return settings;
    }
}