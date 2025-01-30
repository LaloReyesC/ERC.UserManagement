namespace ERC.UserManagement.Core.Interfaces;

public interface ISecurityPassword
{
    /// <summary>
    /// Hashea la contraseña especificada
    /// </summary>
    /// <param name="password">Contraseña que se desea hashear</param>
    /// <returns>Retorna el hash de la contraseña</returns>
    string Hash(string password);

    /// <summary>
    /// Verifica si el hash y la contraseña son correctos
    /// </summary>
    /// <param name="password">Contraseña a verificar</param>
    /// <param name="hash">Hash a verificar</param>
    /// <returns>Retorna una bandera que indica si el hash hace match con la contraseña o no</returns>
    bool ValidHash(string password, string hash);
}