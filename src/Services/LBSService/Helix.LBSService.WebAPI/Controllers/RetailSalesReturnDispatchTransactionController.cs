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
	public class RetailSalesReturnDispatchTransactionController : ControllerBase
	{
		private readonly ILG_RetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
		private readonly ILG_STFICHE_Context _stficheService;

		private ILogger<RetailSalesReturnDispatchTransactionController> _logger;
		public RetailSalesReturnDispatchTransactionController(ILG_RetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService, ILG_STFICHE_Context stficheContext, ILogger<RetailSalesReturnDispatchTransactionController> logger)
		{
			_retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService;
			_logger = logger;
			_stficheService = stficheContext;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert([FromBody] RetailSalesReturnDispatchTransactionDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_RetailSalesReturnDispatchTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_RetailSalesReturnDispatchTransactionLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _retailSalesReturnDispatchTransactionService.Insert(obj);
				return new DataResult<RetailSalesReturnDispatchTransactionDto>()
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
				return new DataResult<RetailSalesReturnDispatchTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
		}

	}
}
