namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class SignInDto : IRequest<SignInResponse>
{
    #region Properties
    public required string UserName { get; set; }

    public required string Password { get; set; }
    #endregion
}