namespace ERC.UserManagement.Infrastructure.Security;

public class PasswordHash : ISecurityPassword
{
    #region Fields
    private readonly PasswordHasher<object> _passwordHasher = new();
    #endregion

    /// <inheritdoc/>
    public string Hash(string password) =>
        _passwordHasher.HashPassword(null, password);

    /// <inheritdoc/>
    public bool VerifyHash(string password, string hash)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hash, password);

        return result == PasswordVerificationResult.Success;
    }
}