namespace ERC.UserManagement.Core.Models.Dtos;

public class UserAccountDto
{
    #region Properties
    public int Id { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public ushort FailedAttemps { get; set; }

    public DateTime RegistrationDate { get; set; }
    #endregion
}