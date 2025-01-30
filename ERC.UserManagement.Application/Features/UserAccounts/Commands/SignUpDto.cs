using MediatR;

namespace ERC.UserManagement.Application.Features.UserAccounts.Commands;

public class SignUpDto : IRequest<SignUpResponse>
{
    #region Properties
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
    #endregion
}