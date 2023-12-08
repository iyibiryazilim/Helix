using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;
public interface IOutCountingTransactionService
{
	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsAsync();
	public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByIdAsync(int id);
	public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByCode(string code);
	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentCodeAsync(string code);
}
