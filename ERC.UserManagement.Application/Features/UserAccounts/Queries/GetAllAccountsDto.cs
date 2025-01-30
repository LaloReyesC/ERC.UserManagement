
namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class GetAllAccountsDto : IRequest<GetAllAccountsResponse>
{
    #region Properties
    [DefaultValue(1)]
    public int DesiredPage { get; set; }

    [DefaultValue(10)]
    public int RowsPerPage { get; set; }
    #endregion
}