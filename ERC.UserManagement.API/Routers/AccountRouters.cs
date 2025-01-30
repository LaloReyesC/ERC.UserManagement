namespace ERC.UserManagement.API.Routers;

public static class AccountRouters
{
    public static void MapAccountEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder testGroup = app!
            .MapGroup("Accounts")
            .WithTags("Accounts");

        testGroup.MapPost(string.Empty, CreateAccountAsync)
                 .WithName(nameof(CreateAccountAsync));

        testGroup.MapGet("{id}", FindAccountAsync)
                 .WithName(nameof(FindAccountAsync));
    }

    #region Private members
    static async Task<IResult> CreateAccountAsync(IMediator mediator, SignUpDto request)
    {
        SignUpResponse response = await mediator.Send(request);

        return response.Success ?
               Results.CreatedAtRoute(nameof(FindAccountAsync), new { id = response.Data }, response) :
               Results.BadRequest(response);
    }

    static async Task<IResult> FindAccountAsync(IMediator mediator, int id)
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
    #endregion
}