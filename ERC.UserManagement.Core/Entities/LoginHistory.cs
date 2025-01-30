namespace ERC.UserManagement.Core.Entities;

public class LoginHistory
{
    #region Properties
    public int Id { get; set; }

    public int UserAccountId { get; set; }

    public DateTime LoginDate { get; set; } = DateTime.Now;
    #endregion

    #region Relations
    public UserAccount? UserAccount { get; set; }
    #endregion
}