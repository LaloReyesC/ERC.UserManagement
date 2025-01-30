namespace ERC.UserManagement.Core.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Crea una nueva cuenta de usuario
    /// </summary>
    /// <param name="userAccount">Contiene toda la información del usuario que será registrado</param>
    /// <returns>retorna el identificador del usuario que ha sido creado</returns>
    Task<int> CreateAsync(UserAccount userAccount);

    /// <summary>
    /// Verifica si existe una cuenta de usuario con la cuenta de correo especificada
    /// </summary>
    /// <param name="email">Cuenta de correo a verificar</param>
    /// <returns>Retorna true en caso que exista la cuenta, de lo contrario false</returns>
    Task<bool> ExistsEmailAsync(string email);

    /// <summary>
    /// Verifica si existe una cuenta de usuario con el nombre de usuario especificado
    /// </summary>
    /// <param name="userName">Nombre de usuario a verificar</param>
    /// <returns>Retorna true en caso que exista el nombre de usario, de lo contrario false</returns>
    Task<bool> ExistsUserNameAsync(string userName);

    /// <summary>
    /// Busca la cuenta de usuario por el identificador de la cuenta
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserAccount?> FindByIdAsync(int id);

    /// <summary>
    /// Busca la cuenta de usuario por el nombre de usuario
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<UserAccount?> FindByUserNameAsync(string userName);

    /// <summary>
    /// Actualiza la información de la cuenta
    /// </summary>
    /// <param name="userAccount"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(UserAccount userAccount);

    /// <summary>
    /// Obtiene el listado de usuarios con paginado
    /// </summary>
    /// <param name="desiredPage"></param>
    /// <param name="rowsPerPage"></param>
    /// <returns></returns>
    Task<IReadOnlyList<UserAccount>?> GetAllAsync(int desiredPage = 1, int rowsPerPage = 10);
}