namespace ERC.UserManagement.Infrastructure.Persistence.Configurations;

internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();

        optionsBuilder.UseSqlite("Data Source=UserManager.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}