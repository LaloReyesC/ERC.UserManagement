namespace ERC.UserManagement.API.Routers;

public static class AccountRouters
{
    public static void MapAccountEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder testGroup = app!
            .MapGroup("Accounts")
            .WithTags("Accounts");

        testGroup.MapPost(string.Empty, CreateAccountAsync);
    }

    #region Private members
    static async Task<IResult> CreateAccountAsync(IMediator mediator, SignUpDto request)
    {
        SignUpResponse response = await mediator.Send(request);

        return response.Success ?
               Results.Created($"/Accounts/{response.Data}", response) :
               Results.BadRequest(response);
    }
    #endregion
}