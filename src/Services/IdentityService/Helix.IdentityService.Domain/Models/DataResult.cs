namespace Helix.IdentityService.Domain.Models;

public class DataResult<T> where T : class
{
    public T? Data  { get; set; }
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; }=string.Empty;

}
