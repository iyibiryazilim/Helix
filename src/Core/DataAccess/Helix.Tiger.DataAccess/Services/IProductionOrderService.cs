using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IProductionOrderService
{
	public Task<DataResult<IEnumerable<ProductionOrder>>> GetProductionOrderList();
	public Task<DataResult<ProductionOrder>> GetProductionOrderById(int id);
	public Task<DataResult<ProductionOrder>> GetProductionOrderByCode(string code);
}
