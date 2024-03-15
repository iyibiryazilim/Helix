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
	public class ProductionTransactionController : ControllerBase
	{
		private readonly ILG_ProductionTransactionService _productionTransactionService;
		private readonly ILG_STFICHE_Context _stficheService;

		private ILogger<ProductionTransactionController> _logger;
		public ProductionTransactionController(ILG_ProductionTransactionService productionTransactionService, ILogger<ProductionTransactionController> logger,ILG_STFICHE_Context stficheContext)
		{
			_productionTransactionService = productionTransactionService;
			_logger = logger;
			_stficheService = stficheContext;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ProductionTransactionDto>> Insert([FromBody] ProductionTransactionDto dto)
		{

			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_ProductionTransaction>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_ProductionTransactionLine>(item);
					obj.TRANSACTIONS.Add(transaction);
				}

				var result = await _productionTransactionService.Insert(obj);
				return new DataResult<ProductionTransactionDto>()
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
				return new DataResult<ProductionTransactionDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
		}
	}
}
