using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RetailSalesReturnDispatchTransactionController : ControllerBase
	{
		 
		private readonly IRetailSalesReturnDispatchTransactionService _service;
		private readonly ILogger<RetailSalesReturnDispatchTransactionController> _logger;
		public RetailSalesReturnDispatchTransactionController(ILogger<RetailSalesReturnDispatchTransactionController> logger, IRetailSalesReturnDispatchTransactionService services)
		{
			_logger = logger;
			_service = services;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert([FromBody] RetailSalesReturnDispatchTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "RetailSalesReturnDispatchTransactionController.Insert");
				return new DataResult<RetailSalesReturnDispatchTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}

	}
}
