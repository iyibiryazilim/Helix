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
    public class OutCountingTransactionController : ControllerBase
    {
        private readonly ILG_OutCountingTransactionService _outCountingTransactionService;
        private ILogger<OutCountingTransactionController> _logger;
        public OutCountingTransactionController(ILG_OutCountingTransactionService outCountingTransactionService, ILogger<OutCountingTransactionController> logger)
        {
            _outCountingTransactionService = outCountingTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<OutCountingTransactionDto>> Insert([FromBody] OutCountingTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_OutCountingTransaction>(dto);
			foreach (var item in dto.Lines)
			{
				var transaction = Mapping.Mapper.Map<LG_OutCountingTransactionLine>(item);
				obj.TRANSACTIONS.Add(transaction);
			}
			var result = await _outCountingTransactionService.Insert(obj);
			return new DataResult<OutCountingTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }

    }
}
