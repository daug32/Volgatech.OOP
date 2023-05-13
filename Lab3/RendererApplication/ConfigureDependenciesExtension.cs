using Microsoft.Extensions.DependencyInjection;
using Renderer.Models.Canvases;
using Renderer.Models.Canvases.Implementation;
using RendererApplication.Models;

namespace RendererApplication;

public static class ConfigureDependenciesExtension
{
    public static IServiceCollection ConfigureDependencies(
        this IServiceCollection services,
        RendererSettings rendererSettings )
    {
        services.AddSingleton(
            serviceProvider =>
            {
                ICanvas canvas = serviceProvider.GetRequiredService<ICanvas>();

                return new RendererApplication( canvas, rendererSettings );
            } );

        services.AddScoped<ICanvas, CCanvas>(
            _ => new CCanvas(
                RendererSettings.DefaultCanvasWidth,
                RendererSettings.DefaultCanvasHeight ) );

        return services;
    }
}