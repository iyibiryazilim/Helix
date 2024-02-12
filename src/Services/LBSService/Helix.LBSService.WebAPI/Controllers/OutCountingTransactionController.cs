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
    public class OutCountingTransactionController : ControllerBase
    {
		private readonly ILG_STFICHE_Context _stficheService;
        private readonly ILG_OutCountingTransactionService _outCountingTransactionService;
		private ILogger<OutCountingTransactionController> _logger;
        public OutCountingTransactionController(ILG_OutCountingTransactionService outCountingTransactionService, ILogger<OutCountingTransactionController> logger,ILG_STFICHE_Context stficheContext)
        {
            _outCountingTransactionService = outCountingTransactionService;
            _logger = logger;
			_stficheService = stficheContext;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<OutCountingTransactionDto>> Insert([FromBody] OutCountingTransactionDto dto)
        {
            if (LBSParameter.IsTiger)
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
			else
			{
				var obj = Mapping.Mapper.Map<LG_STFICHE>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_STLINE>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _stficheService.InsertObject(obj);
				return new DataResult<OutCountingTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
		}

    }
}
