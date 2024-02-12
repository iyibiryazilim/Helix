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
    public class WholeSalesReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_WholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;
        private ILogger<WholeSalesReturnDispatchTransactionController> _logger;
        public WholeSalesReturnDispatchTransactionController(ILG_WholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService, ILogger<WholeSalesReturnDispatchTransactionController> logger)
        {
            _wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<WholeSalesReturnTransactionDto>> Insert([FromBody] WholeSalesReturnTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_WholeSalesReturnDispatchTransaction>(dto);
			foreach (var item in dto.Lines)
			{
				var transaction = Mapping.Mapper.Map<LG_WholeSalesReturnDispatchLine>(item);
				obj.TRANSACTIONS.Add(transaction);
			}
			var result = await _wholeSalesReturnDispatchTransactionService.Insert(obj);
			return new DataResult<WholeSalesReturnTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }
    }
}
