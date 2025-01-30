using MediatR;

namespace ERC.UserManagement.API.Routers;

public static class AccountRouters
{
    public static void MapAccountEndPoints(this WebApplication? app)
    {
        RouteGroupBuilder testGroup = app!
            .MapGroup("Accounts")
            .WithTags("Accounts");

        testGroup.MapPost(string.Empty, (IMediator mediator) =>
        {
            return Results.Ok();
        });
    }
}