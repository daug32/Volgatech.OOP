using Microsoft.Extensions.DependencyInjection;
using RendererApplication.UserInput;

namespace RendererApplication;

public static class ConfigureDependenciesExtension
{
    public static IServiceCollection ConfigureDependencies( this IServiceCollection services )
    {
        services.AddScoped<IUserInterfaceHandler>( _ => new UserInterfaceHandler( Console.Out, Console.In ) );
        services.AddScoped<TaskHandler>();
        services.AddSingleton<RendererApplication>();

        return services;
    }
}