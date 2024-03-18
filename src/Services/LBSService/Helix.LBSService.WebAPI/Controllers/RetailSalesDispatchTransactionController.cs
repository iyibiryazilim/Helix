using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class RetailSalesDispatchTransactionController : ControllerBase
    {
        
		private readonly IRetailSalesDispatchTransactionService _service;
		private ILogger<RetailSalesDispatchTransactionController> _logger;
		public RetailSalesDispatchTransactionController(ILogger<RetailSalesDispatchTransactionController> logger, IRetailSalesDispatchTransactionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpPost("Insert")]
        public async Task<DataResult<RetailSalesDispatchTransactionDto>> Insert([FromBody] RetailSalesDispatchTransactionDto dto)
        {
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "RetailSalesDispatchTransactionController.Insert");
				return new DataResult<RetailSalesDispatchTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
    }
}
