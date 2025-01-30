namespace ERC.UserManagement.Core.Models.Options;

public class JwtSettings
{
    #region Properties
    public required string SecretKey { get; set; }

    public required string Issuer { get; set; }

    public required string Audience { get; set; }

    public int ExpiresInMinutes { get; set; }
    #endregion
}