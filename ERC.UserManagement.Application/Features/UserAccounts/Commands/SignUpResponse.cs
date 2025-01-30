namespace ERC.UserManagement.Application.Features.UserAccounts.Commands;

public class SignUpResponse : ResponseDto<int>
{
    internal SignUpResponse BuildError(string message)
    {
        Details.Add(message);

        return this;
    }

    internal SignUpResponse Created(int id)
    {
        Success = true;
        Data = id;

        return this;
    }
}