using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RendererApplication;

internal class Program
{
    private static void Main( string[] args )
    {
        BuildHost( args )
            .Services
            .GetRequiredService<RendererApplication>()
            .Start();
    }

    private static IHost BuildHost( string[] args )
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(
                services => services.ConfigureDependencies() )
            .Build();
    }
}