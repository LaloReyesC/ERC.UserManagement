namespace ERC.UserManagement.Infrastructure.Persistence.Repositories;

public class LoginHistoryRepository(ApplicationDbContext dbContext) : ILoginHistoryRepository
{
    #region Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    /// <inheritdoc/>
    public async Task<int> CreateAsync(LoginHistory history)
    {
        _dbContext.LoginHistories.Add(history);

        await _dbContext.SaveChangesAsync();

        return history.Id;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<LoginHistory>?> GetAllAsync(int desiredPage = 1, int rowsPerPage = 10)
    {
        IQueryable<LoginHistory> query = _dbContext.LoginHistories.AsQueryable()
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .Include(x => x.UserAccount);

        query = query.Skip((desiredPage - 1) * rowsPerPage)
                     .Take(rowsPerPage);

        return await query.ToListAsync();
    }
}