using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WastageTransactionController : ControllerBase
	{
		private readonly ILG_STFICHE_Context _stficheService;
		private readonly ILG_WastageTransactionService _consumableTransactionService;
		private ILogger<ConsumableTransactionController> _logger;
		public WastageTransactionController(ILG_WastageTransactionService consumableTransactionService, ILG_STFICHE_Context stficheService, ILogger<ConsumableTransactionController> logger)
		{
			_stficheService = stficheService;
			_consumableTransactionService = consumableTransactionService;
			_logger = logger;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<WastageTransactionDto>> Insert([FromBody] WastageTransactionDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_WastageTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_WastageTransactionLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _consumableTransactionService.Insert(obj);
				return new DataResult<WastageTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			else
			{
				var obj = Mapping.Mapper.Map<LG_STFICHE>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_STLINE>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _stficheService.InsertObject(obj);
				return new DataResult<WastageTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}

		}
	}
}
