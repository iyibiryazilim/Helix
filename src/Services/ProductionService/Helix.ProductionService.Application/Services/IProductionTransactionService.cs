using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IProductionTransactionService
{
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync();
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id);
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code);
}
