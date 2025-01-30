namespace ERC.UserManagement.API.Routers;

public static class AccountRouters
{
    public static void MapAccountEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder group = app!
            .MapGroup("Accounts")
            .WithTags("Accounts")
            .RequireAuthorization();

        group.MapGet("", GetAllAccountAsync)
                 .WithName(nameof(GetAllAccountAsync));

        group.MapGet("{id}", FindAccountAsync)
                 .WithName(nameof(FindAccountAsync));
    }

    #region Private members
    static async Task<IResult> FindAccountAsync(IMediator mediator, int id)
    {
        FindUserAccountResponse? response = await mediator.Send(new FindUserAccountDto(id));

        if (response is null)
        {
            throw new NotFoundException("La cuenta no se encuentra registrada.");
        }

        return Results.Ok(response);
    }

    static async Task<IResult> GetAllAccountAsync(IMediator mediator, [AsParameters] GetAllAccountsDto request)
    {
        GetAllAccountsResponse? response = await mediator.Send(request);

        return response is null ? throw new NotFoundException("La busqueda no ha generado registros.") : Results.Ok(response);
    }
    #endregion
}