namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class GetAllAccountsHandler(IUserRepository userRepository) : IRequestHandler<GetAllAccountsDto, GetAllAccountsResponse>
{
    #region Fields
    private readonly IUserRepository _userRepository = userRepository;
    #endregion

    public async Task<GetAllAccountsResponse> Handle(GetAllAccountsDto request, CancellationToken cancellationToken)
    {
        GetAllAccountsResponse response = new();
        IReadOnlyList<UserAccount>? userAccount = await _userRepository.GetAllAsync(request.DesiredPage, request.RowsPerPage);

        if (userAccount is null)
        {
            return response;
        }

        response.Items = userAccount.Adapt<IReadOnlyList<UserAccountDto>>();

        return response;
    }
}