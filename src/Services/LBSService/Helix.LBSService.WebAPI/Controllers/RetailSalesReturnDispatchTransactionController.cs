using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class RetailSalesReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_RetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
        private ILogger<RetailSalesReturnDispatchTransactionController> _logger;
        public RetailSalesReturnDispatchTransactionController(ILG_RetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService, ILogger<RetailSalesReturnDispatchTransactionController> logger)
        {
            _retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert([FromBody] RetailSalesReturnDispatchTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_RetailSalesReturnDispatchTransaction>(dto);
			var result = await _retailSalesReturnDispatchTransactionService.Insert(obj);
			return new DataResult<RetailSalesReturnDispatchTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }

    }
}
