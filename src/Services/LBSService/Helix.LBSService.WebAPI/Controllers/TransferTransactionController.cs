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
    public class TransferTransactionController : ControllerBase
    {
        private readonly ILG_TransferTransactionService _transferTransactionService;
        private ILogger<TransferTransactionController> _logger;
        public TransferTransactionController(ILG_TransferTransactionService transferTransactionService, ILogger<TransferTransactionController> logger)
        {
            _transferTransactionService = transferTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<TransferTransactionDto>> Insert([FromBody] TransferTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_TransferTransaction>(dto);
			foreach (var item in dto.Lines)
			{
				var transaction = Mapping.Mapper.Map<LG_TransferTransactionLine>(item);
				obj.TRANSACTIONS.Add(transaction);
			}
			var result = await _transferTransactionService.Insert(obj);
			return new DataResult<TransferTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }
    }
}
