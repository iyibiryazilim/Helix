using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;

using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class InCountingTransactionController : ControllerBase
    {
        private readonly ILG_InCountingTransactionService _inCountingTransactionService;
		private readonly ILG_STFICHE_Context _stficheService;

		private ILogger<InCountingTransactionController> _logger;
        public InCountingTransactionController(ILG_InCountingTransactionService inCountingTransactionService, ILogger<InCountingTransactionController> logger,ILG_STFICHE_Context stficheService)
        {
            _inCountingTransactionService = inCountingTransactionService;
            _logger = logger;
			_stficheService = stficheService;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<InCountingTransactionDto>> Insert([FromBody] InCountingTransactionDto dto)
        {
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_InCountingTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_InCountingTransactionLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _inCountingTransactionService.Insert(obj);

				return new DataResult<InCountingTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			else
			{
				var obj = Mapping.Mapper.Map<LG_STFICHE>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_STLINE>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _stficheService.InsertObject(obj);
				return new DataResult<InCountingTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
         }


    }
}
