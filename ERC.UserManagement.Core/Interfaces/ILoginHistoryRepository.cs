namespace ERC.UserManagement.Core.Interfaces;

public interface ILoginHistoryRepository
{
    /// <summary>
    /// Crea una nuevo registro de inicio de sesión
    /// </summary>
    /// <param name="userAccount">Contiene toda la información del usuario que será registrado</param>
    /// <returns>retorna el identificador del usuario que ha sido creado</returns>
    Task<int> CreateAsync(LoginHistory userAccount);

    /// <summary>
    /// Obtiene el listado de inicios de sesión
    /// </summary>
    /// <param name="desiredPage"></param>
    /// <param name="rowsPerPage"></param>
    /// <returns></returns>
    Task<IReadOnlyList<LoginHistory>?> GetAllAsync(int desiredPage = 1, int rowsPerPage = 10);
}