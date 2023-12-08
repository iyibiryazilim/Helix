using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;

public interface IInCountingTransactionService
{
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsAsync();
	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByIdAsync(int id);
	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByCode(string code);
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentCodeAsync(string code);
}
