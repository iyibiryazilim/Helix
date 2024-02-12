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
    public class RetailSalesDispatchTransactionController : ControllerBase
    {
        private readonly ILG_RetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
        private ILogger<RetailSalesDispatchTransactionController> _logger;
        public RetailSalesDispatchTransactionController(ILG_RetailSalesDispatchTransactionService retailSalesDispatchTransactionService, ILogger<RetailSalesDispatchTransactionController> logger)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<RetailSalesDispatchTransactionDto>> Insert([FromBody] RetailSalesDispatchTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_RetailSalesDispatchTransaction>(dto);
			foreach (var item in dto.Lines)
			{
				var transaction = Mapping.Mapper.Map<LG_RetailSalesDispatchTransactionLine>(item);
				obj.TRANSACTIONS.Add(transaction);
			}
			var result = await _retailSalesDispatchTransactionService.Insert(obj);
			return new DataResult<RetailSalesDispatchTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			}; 
        }
    }
}
