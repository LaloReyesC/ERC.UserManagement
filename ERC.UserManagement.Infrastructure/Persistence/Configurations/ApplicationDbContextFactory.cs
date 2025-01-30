namespace ERC.UserManagement.Infrastructure.Persistence.Configurations;

internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();

        optionsBuilder.UseSqlite(Constants.SqliteConnectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}