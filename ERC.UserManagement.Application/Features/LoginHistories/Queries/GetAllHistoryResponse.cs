namespace ERC.UserManagement.Application.Features.LoginHistories.Queries;

public class GetAllHistoryResponse
{
	#region Properties
	public IReadOnlyList<LoginHistoryDto>? Items { get; set; }
	#endregion
}