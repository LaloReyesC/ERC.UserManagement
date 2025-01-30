namespace ERC.UserManagement.Application;

public static class LayerDependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(LayerDependencies).Assembly));

        return services;
    }
}