using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class WholeSalesDispatchTransactionController : ControllerBase
    {
        private readonly ILG_WholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
        private ILogger<WholeSalesDispatchTransactionController> _logger;
        public WholeSalesDispatchTransactionController(ILG_WholeSalesDispatchTransactionService wholeSalesDispatchTransactionService, ILogger<WholeSalesDispatchTransactionController> logger)
        {
            _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<WholeSalesDispatchTransactionDto>> Insert([FromBody] WholeSalesDispatchTransactionDto dto)
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
    }
}
