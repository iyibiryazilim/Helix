using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IProductionOrderService
{
	public Task<DataResult<IEnumerable<ProductionOrder>>> GetProductionOrderList();
	public Task<DataResult<ProductionOrder>> GetProductionOrderByCode(string code);
	public Task<DataResult<ProductionOrder>> GetProductionOrderById(int id);
}
