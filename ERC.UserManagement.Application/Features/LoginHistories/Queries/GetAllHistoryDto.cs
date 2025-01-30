namespace ERC.UserManagement.Application.Features.LoginHistories.Queries;

public class GetAllHistoryDto : IRequest<GetAllHistoryResponse>
{
    #region Properties
    [DefaultValue(1)]
    public int DesiredPage { get; set; }

    [DefaultValue(10)]
    public int RowsPerPage { get; set; }
    #endregion
}