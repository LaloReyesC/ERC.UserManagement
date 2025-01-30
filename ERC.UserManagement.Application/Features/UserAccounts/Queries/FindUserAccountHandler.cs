namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class FindUserAccountHandler(IUserRepository userRepository) : IRequestHandler<FindUserAccountDto, FindUserAccountResponse?>
{
    #region Fields
    private readonly IUserRepository _userRepository = userRepository;
    #endregion

    public async Task<FindUserAccountResponse?> Handle(FindUserAccountDto request, CancellationToken cancellationToken)
    {
        UserAccount? userAccount = await _userRepository.FindByIdAsync(request.Id);

        if (userAccount is null)
        {
            return default;
        }

        return userAccount.Adapt<FindUserAccountResponse>();
    }
}