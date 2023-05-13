using Microsoft.Extensions.DependencyInjection;
using RendererApplication.Models;
using RendererApplication.Models.Canvases;

namespace RendererApplication;

public static class ConfigureDependenciesExtension
{
    public static IServiceCollection ConfigureDependencies(
        this IServiceCollection services,
        RendererSettings rendererSettings )
    {
        services.AddSingleton<RendererApplication>( serviceProvider =>
        {
            ICCanvas canvas = serviceProvider.GetRequiredService<ICCanvas>();
            
            return new RendererApplication( canvas, rendererSettings );
        } );
        
        services.AddScoped<ICCanvas, CCanvas>( _ => new CCanvas(
            rendererSettings.DefaultCanvasWidth, 
            rendererSettings.DefaultCanvasHeight ) );

        return services;
    }
}