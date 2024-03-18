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
	public class WholeSalesDispatchTransactionController : ControllerBase
	{
		private readonly ILG_WholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
		private readonly ILG_STFICHE_Context _stficheService;

		private ILogger<WholeSalesDispatchTransactionController> _logger;
		public WholeSalesDispatchTransactionController(ILG_WholeSalesDispatchTransactionService wholeSalesDispatchTransactionService, ILG_STFICHE_Context stficheContext, ILogger<WholeSalesDispatchTransactionController> logger)
		{
			_wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
			_logger = logger;
			_stficheService = stficheContext;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<WholeSalesDispatchTransactionDto>> Insert([FromBody] WholeSalesDispatchTransactionDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_WholeSalesDispatchTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_WholeSalesDispatchLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _wholeSalesDispatchTransactionService.Insert(obj);
				return new DataResult<WholeSalesDispatchTransactionDto>()
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
				var result = await _stficheService.InsertObjectAsync(obj);
				return new DataResult<WholeSalesDispatchTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};

			}
		}
	}
}
