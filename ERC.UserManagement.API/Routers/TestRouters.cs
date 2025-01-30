namespace ERC.UserManagement.API.Routers;

public static class TestRouters
{
    public static void MapTestEndPoints(this WebApplication? app)
    {
        if (!app!.Environment.IsDevelopment())
        {
            return;
        }

        RouteGroupBuilder testGroup = app
            .MapGroup("Test")
            .WithTags("Test");

        testGroup.MapGet("Connection", Connection);
        testGroup.MapGet("DataBase", DataBase);
    }

    #region Private members
    /// <summary>
    /// Método para la prueba de conexión del API
    /// </summary>
    /// <returns>Retorna un mensaje que indica que fue existosa la conexión</returns>
    static IResult Connection()
    {
        return Results.Ok(new
        {
            message = "Prueba de conexión exitosa."
        });
    }

    /// <summary>
    /// Realiza una prueba de conexión con la BD
    /// </summary>
    /// <param name="dbContext">DI: Contexto de datos</param>
    /// <returns></returns>
    static async Task<IResult> DataBase(ApplicationDbContext dbContext)
    {
        int currentUsersNumber = await dbContext.UserAccounts.CountAsync();

        return Results.Ok(new
        {
            message = $"'{currentUsersNumber}' usuarios registrados actualmente."
        });
    }
    #endregion
}