using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;
public interface IProductionTransactionService
{
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync();
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id);
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code);
}
