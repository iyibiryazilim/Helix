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
    public class RetailSalesDispatchTransactionController : ControllerBase
    {
        private readonly ILG_RetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
		private readonly ILG_STFICHE_Context _stficheService;

		private ILogger<RetailSalesDispatchTransactionController> _logger;
        public RetailSalesDispatchTransactionController(ILG_RetailSalesDispatchTransactionService retailSalesDispatchTransactionService, ILG_STFICHE_Context stficheContext,ILogger<RetailSalesDispatchTransactionController> logger)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
            _logger = logger;
			_stficheService = stficheContext;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<RetailSalesDispatchTransactionDto>> Insert([FromBody] RetailSalesDispatchTransactionDto dto)
        {
            if (LBSParameter.IsTiger)
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
			else
			{
				var obj = Mapping.Mapper.Map<LG_STFICHE>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_STLINE>(item);
					obj.TRANSACTIONS.Add(transaction);
				}
				var result = await _stficheService.InsertObjectAsync(obj);
				return new DataResult<RetailSalesDispatchTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
        }
    }
}
