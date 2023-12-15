using Helix.IdentityService.Domain.Models;

namespace Helix.IdentityService.Application.Repository;

public interface IIdentityService
{
	Task<LoginResponseModel> Login(LoginRequestModel requestModel);
}
