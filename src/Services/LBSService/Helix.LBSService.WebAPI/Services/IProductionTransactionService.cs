using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IProductionTransactionService
	{
		public Task<DataResult<ProductionTransactionDto>> Insert(ProductionTransactionDto dto);
	}
}
