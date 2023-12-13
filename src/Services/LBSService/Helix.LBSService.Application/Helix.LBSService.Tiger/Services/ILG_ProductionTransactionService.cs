using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_ProductionTransactionService
	{
		Task<DataResult<ProductionTransactionDto>> Insert(ProductionTransactionDto dto);

	}
}
