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
    public class InCountingTransactionController : ControllerBase
    {
        private readonly ILG_InCountingTransactionService _inCountingTransactionService;
        private ILogger<InCountingTransactionController> _logger;
        public InCountingTransactionController(ILG_InCountingTransactionService inCountingTransactionService, ILogger<InCountingTransactionController> logger)
        {
            _inCountingTransactionService = inCountingTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<InCountingTransactionDto>> Insert([FromBody] InCountingTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_InCountingTransaction>(dto);
			var result = await _inCountingTransactionService.Insert(obj);

			return new DataResult<InCountingTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
			
         }


    }
}
