namespace ERC.UserManagement.Application.Features.LoginHistories.Queries;

public class GetAllHistoryHandler(ILoginHistoryRepository loginRepository) : IRequestHandler<GetAllHistoryDto, GetAllHistoryResponse>
{
    #region Fields
    private readonly ILoginHistoryRepository _loginRepository = loginRepository;
    #endregion

    public async Task<GetAllHistoryResponse> Handle(GetAllHistoryDto request, CancellationToken cancellationToken)
    {
        GetAllHistoryResponse response = new();
        IReadOnlyList<LoginHistory>? loginHistories = await _loginRepository.GetAllAsync(request.DesiredPage, request.RowsPerPage);

        if (loginHistories is null)
        {
            return response;
        }

        response.Items = loginHistories.Adapt<IReadOnlyList<LoginHistoryDto>>();

        return response;
    }
}