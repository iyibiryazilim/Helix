using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalesOrderController : ControllerBase
	{
		private readonly ILG_SalesOrderService _service;
 
		private ILogger<SalesOrderController> _logger;
		public SalesOrderController(ILG_SalesOrderService purchaseDispatchTransactionService, ILogger<SalesOrderController> logger)
		{
			_service = purchaseDispatchTransactionService;
			_logger = logger;
		}


		[HttpPost("Insert")]
		public async Task<DataResult<SalesOrderDto>> Insert([FromBody] SalesOrderDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_SalesOrder>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_SalesOrderLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _service.Insert(obj);
				return new DataResult<SalesOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			} 
			else
			{
				return new DataResult<SalesOrderDto>()
				{
					Data = null,
					Message = "Not Implemented",
					IsSuccess = false,
				};
			}
		}
	}
}
