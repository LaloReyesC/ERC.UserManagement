
namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class FindUserAccountDto(int id) : IRequest<FindUserAccountResponse?>
{
    #region Properties
    public int Id { get; set; } = id;
    #endregion
}