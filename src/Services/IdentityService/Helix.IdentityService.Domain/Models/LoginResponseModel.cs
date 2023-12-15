namespace Helix.IdentityService.Domain.Models;

public class LoginResponseModel
{
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
