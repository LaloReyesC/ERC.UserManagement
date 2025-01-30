namespace ERC.UserManagement.API.Routers;

public static class LoginHistoryRouters
{
    public static void MapLoginHistoryEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder group = app!
            .MapGroup("LoginHistory")
            .WithTags("LoginHistory")
            .RequireAuthorization();

        group.MapGet("", GetAllHistoriesAsync)
                 .WithName(nameof(GetAllHistoriesAsync));
    }

    #region Private members
    static async Task<IResult> GetAllHistoriesAsync(IMediator mediator, [AsParameters] GetAllHistoryDto request)
    {
        GetAllHistoryResponse? response = await mediator.Send(request);

        return response is null ? throw new NotFoundException("La busqueda no ha generado registros.") : Results.Ok(response);
    }
    #endregion
}