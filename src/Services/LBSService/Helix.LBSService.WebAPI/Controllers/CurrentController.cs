using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrentController : ControllerBase
	{
		private readonly ILG_CurrentService _currentService;
		public CurrentController(ILG_CurrentService currentService)
		{
			_currentService = currentService;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<CurrentDto>> Insert([FromBody] CurrentDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_Current>(dto);

				var result = await _currentService.Insert(obj);

				return new DataResult<CurrentDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			else
			{
				throw new HttpRequestException("Not implemented for GO");
			}

		}
	}
}
