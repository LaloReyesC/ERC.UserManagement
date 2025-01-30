namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class GetAllAccountsResponse
{
    public IReadOnlyList<UserAccountDto>? Items { get; set; }
}