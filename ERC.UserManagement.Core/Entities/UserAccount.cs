namespace ERC.UserManagement.Core.Entities;

public class UserAccount
{
    #region Properties
    public int Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public ushort FailedAttemps { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    #endregion

    #region Relations
    public ICollection<LoginHistory>? LoginHistories { get; set; }
    #endregion
}