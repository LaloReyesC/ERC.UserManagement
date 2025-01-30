namespace ERC.UserManagement.API.Routers;

public static class AccountRouters
{
    public static void MapAccountEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder group = app!
            .MapGroup("Accounts")
            .WithTags("Accounts");

        group.MapGet("{id}", FindAccountAsync)
                 .WithName(nameof(FindAccountAsync));
    }

    #region Private members
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