namespace ERC.UserManagement.Application.Features.UserAccounts.Queries;

public class SignInHandler(IUserRepository userRepository,
                       ISecurityPassword securityPassword,
                       IOptions<JwtSettings> JwtSettingsOptions) : IRequestHandler<SignInDto, SignInResponse>
{
    #region Fields
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ISecurityPassword _securityPassword = securityPassword;
    private readonly JwtSettings _jwtSettings = JwtSettingsOptions.Value;
    #endregion

    public async Task<SignInResponse> Handle(SignInDto request, CancellationToken cancellationToken)
    {
        UserAccount user = await _userRepository.FindByUserNameAsync(request.UserName) ??
            throw new ApplicationException("Usuario o contraseña incorrectos.");

        if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
        {
            throw new ApplicationException("Cuenta bloqueada. Intenta de nuevo más tarde.");
        }

        if (!_securityPassword.ValidHash(request.Password, user.PasswordHash))
        {
            user.FailedAttemps++;

            if (user.FailedAttemps >= 3)
            {
                user.LockoutEnd = DateTime.Now.AddMinutes(30);
            }

            _ = await _userRepository.UpdateAsync(user);

            throw new ApplicationException("Usuario o contraseña incorrectos.");
        }

        user.FailedAttemps = 0;

        var token = GenerateToken(user, _jwtSettings);

        return new()
        {
            AccessToken = token,
            RefreshToken = $"{Guid.NewGuid():N}"
        };
    }

    #region Private members
    static string GenerateToken(UserAccount user, JwtSettings jwtSettings)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.UserName),
            new(JwtRegisteredClaimNames.Nickname, user.UserName),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("UserId", user.Id.ToString())
        ];

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.ExpiresInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion
}