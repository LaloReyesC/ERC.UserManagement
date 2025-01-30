namespace ERC.UserManagement.Application.Features.UserAccounts.Commands;

public class SignUpHandler(IUserRepository userRepository,
    ISecurityPassword securityPassword) : IRequestHandler<SignUpDto, SignUpResponse>
{
    #region Fields
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ISecurityPassword _securityPassword = securityPassword;
    #endregion

    public async Task<SignUpResponse> Handle(SignUpDto request, CancellationToken cancellationToken)
    {
        SignUpResponse response = new();

        if (await _userRepository.ExistsUserNameAsync(request.UserName))
        {
            return response.BuildError("El nombre de usuario ya está en uso.");
        }
        else if (await _userRepository.ExistsEmailAsync(request.Email))
        {
            return response.BuildError("El correo electrónico ya está en uso.");
        }

        UserAccount user = request.Adapt<UserAccount>();

        user.PasswordHash = _securityPassword.Hash(request.Password);

        await _userRepository.CreateAsync(user);

        return response.Created(user.Id);
    }
}