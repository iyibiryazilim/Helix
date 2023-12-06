using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IInCountingTransactionService
{
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsAsync();
	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByIdAsync(int id);
	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByCode(string code);
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentCodeAsync(string code);
}
