namespace ERC.UserManagement.Core.Entities;

public class UserAccount
{
    #region Properties
    public int Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public DateTime RegistrationDate { get; set; }
    #endregion

    #region Relations
    public ICollection<LoginHistory> LoginHistories { get; set; }
    #endregion
}