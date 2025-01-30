namespace ERC.UserManagement.Infrastructure.Persistence.Repositories;

public class UserRepositoty(ApplicationDbContext dbContext) : IUserRepository
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    /// <inheritdoc/>
    public async Task<int> CreateAsync(UserAccount userAccount)
    {
        _dbContext.UserAccounts.Add(userAccount);

        await _dbContext.SaveChangesAsync();

        return userAccount.Id;
    }

    /// <inheritdoc/>
    public async Task<bool> ExistsEmailAsync(string email) =>
        await _dbContext.UserAccounts.AnyAsync(u => u.Email == email);

    /// <inheritdoc/>
    public async Task<bool> ExistsUserNameAsync(string userName) =>
        await _dbContext.UserAccounts.AnyAsync(u => u.UserName == userName);

    /// <inheritdoc/>
    public async Task<UserAccount?> FindByIdAsync(int id) =>
        await _dbContext.UserAccounts.FirstOrDefaultAsync(u => u.Id == id);
}