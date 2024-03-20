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
	public class VariantController : ControllerBase
	{
		private readonly ILG_VariantService _variantService;

		public VariantController(ILG_VariantService variantService)
		{
			_variantService = variantService;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<VariantDto>> Insert([FromBody] VariantDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_Variant>(dto);

				foreach (var item in dto.Lines)
				{
					var variantAssign = Mapping.Mapper.Map<LG_VRNTASSIGN>(item);
					obj.VRNT_ASSIGNS.Add(variantAssign);
				}

				var result = await _variantService.Insert(obj);

				return new DataResult<VariantDto>()
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