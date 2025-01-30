namespace ERC.UserManagement.Core.Models.Dtos;

public class LoginHistoryDto
{
    #region Properties
    public int Id { get; set; }

    public int UserAccountId { get; set; }

    public DateTime LoginDate { get; set; }
    #endregion

    #region Relations
    public UserAccountDto? UserAccount { get; set; }
    #endregion
}