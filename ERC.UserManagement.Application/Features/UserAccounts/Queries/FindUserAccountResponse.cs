namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class FindUserAccountResponse
{
    #region Properties
    public int Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public ushort FailedAttemps { get; set; }

    public DateTime RegistrationDate { get; set; }
    #endregion
}