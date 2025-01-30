namespace ERC.UserManagement.Infrastructure;

public static class LayerDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlite(Constants.SqliteConnectionString);
        });

        return services;
    }
}