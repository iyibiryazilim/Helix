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
	public class ConsumableTransactionController : ControllerBase
	{
		private readonly ILG_STFICHE_Context _stficheService;
		private readonly ILG_ConsumableTransactionService _consumableTransactionService;
		private ILogger<ConsumableTransactionController> _logger;
		public ConsumableTransactionController(ILG_ConsumableTransactionService consumableTransactionService, ILG_STFICHE_Context stficheService, ILogger<ConsumableTransactionController> logger)
		{
			_stficheService = stficheService;
			_consumableTransactionService = consumableTransactionService;
			_logger = logger;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ConsumableTransactionDto>> Insert([FromBody] ConsumableTransactionDto dto)
		{ 
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_ConsumableTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_ConsumableTransactionLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _consumableTransactionService.Insert(obj); 
		 
				return new DataResult<ConsumableTransactionDto>()
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
				//Gonna publish LOGO.FailureEvent 
				return new DataResult<ConsumableTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}

		}
	}
}
