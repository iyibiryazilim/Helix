using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariantController : ControllerBase
	{
		private readonly ILogger<VariantController> _logger;
		private readonly IVariantService _service;

		public VariantController(ILogger<VariantController> logger, IVariantService variantService)
		{
			_logger = logger;
			_service = variantService;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<VariantDto>> Insert([FromBody] VariantDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "VariantController.Insert");
				return new DataResult<VariantDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}