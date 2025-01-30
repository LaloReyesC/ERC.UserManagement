namespace ERC.UserManagement.API.Routers;

public static class AuthRouters
{
    public static void MapAuthEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder group = app!
            .MapGroup("Auth")
            .WithTags("Auth");

        group.MapPost("SignUp", CreateAccountAsync)
                 .WithName(nameof(CreateAccountAsync));

        group.MapPost("SignIn", SignInAsync)
                 .WithName(nameof(SignInAsync));

        group.MapPost("RefreshToken", RefreshToken)
                 .WithName(nameof(RefreshToken));
    }

    #region Private members
    static async Task<IResult> SignInAsync(IMediator mediator, SignInDto request)
    {
        SignInResponse response = await mediator.Send(request);

        return Results.Ok(response);
    }

    static async Task<IResult> RefreshToken(IMediator mediator, int id)
    {
        FindUserAccountResponse? response = await mediator.Send(new FindUserAccountDto(id));

        if (response is null)
        {
            ResponseDto<object> notFoundResult = new();

            notFoundResult.AddDetail("La cuenta no se encuentra registrada.");

            return Results.NotFound(notFoundResult);
        }

        return Results.Ok(response);
    }

    static async Task<IResult> CreateAccountAsync(IMediator mediator, SignUpDto request)
    {
        SignUpResponse response = await mediator.Send(request);

        return response.Success ?
               Results.CreatedAtRoute("FindAccountAsync", new { id = response.Data }, response) :
               Results.BadRequest(response);
    }

    #endregion
}