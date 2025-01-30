namespace ERC.UserManagement.Application.Features.Commons;

public class ResponseDto<T>
{
    #region Properties
    public List<string> Details { get; } = [];

    public bool Success { get; internal set; }

    public T? Data { get; set; }
    #endregion
}