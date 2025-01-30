namespace ERC.UserManagement.Infrastructure.Persistence.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    #region Properties
    public DbSet<UserAccount> UserAccounts { get; set; }

    public DbSet<LoginHistory> LoginHistories { get; set; }
    #endregion

    #region Override members
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserAccountConfigurations());
        modelBuilder.ApplyConfiguration(new LoginHistoryConfigurations());
    }
    #endregion
}