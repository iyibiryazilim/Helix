using Helix.IdentityService.Application.Repository;
using Helix.IdentityService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.IdentityService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequest)
		{
			var result = await _identityService.Login(loginRequest);
			return Ok(result);
		}
    }
}
