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
	public class ProductionTransactionController : ControllerBase
	{
		private readonly ILG_ProductionTransactionService _productionTransactionService;
		private ILogger<ProductionTransactionController> _logger;
		public ProductionTransactionController(ILG_ProductionTransactionService productionTransactionService, ILogger<ProductionTransactionController> logger)
		{
			_productionTransactionService = productionTransactionService;
			_logger = logger;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ProductionTransactionDto>> Insert([FromBody] ProductionTransactionDto dto)
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
	}
}
