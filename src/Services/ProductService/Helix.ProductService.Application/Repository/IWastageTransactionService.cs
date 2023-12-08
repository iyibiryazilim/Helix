using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;
public interface IWastageTransactionService
{
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsAsync();
	public Task<DataResult<WastageTransaction>> GetWastageTransactionByIdAsync(int id);
	public Task<DataResult<WastageTransaction>> GetWastageTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentCodeAsync(string code);
}
