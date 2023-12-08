using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;

public interface IConsumableTransactionService
{
	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsAsync();
	public Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByIdAsync(int id);
	public Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByCode(string code);
	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentCodeAsync(string code);
}
