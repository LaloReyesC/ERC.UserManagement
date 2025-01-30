namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class SignInResponse
{
    #region Properties
    public required string AccessToken { get; set; }

    public required string RefreshToken { get; set; }
    #endregion
}