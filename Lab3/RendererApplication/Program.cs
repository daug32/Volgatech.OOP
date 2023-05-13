using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RendererApplication.Builders;
using RendererApplication.Models;

namespace RendererApplication;

internal class Program
{
    private static void Main( string[] args )
    {
        BuildHost( args )
            .Services
            .GetRequiredService<RendererApplication>()
            .Draw();

        Console.WriteLine( "Executing is completed. Type any key to exit." );
        Console.ReadKey();
    }

    private static IHost BuildHost( string[] args )
    {
        RendererSettings rendererSettings = RendererSettingsBuilder.Build( args );
        
        return Host.CreateDefaultBuilder()
            .ConfigureServices(
                services =>
                {
                    services.ConfigureDependencies( rendererSettings );
                } )
            .Build();
    }
}