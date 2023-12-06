using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IWastageTransactionService
{
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsAsync();
	public Task<DataResult<WastageTransaction>> GetWastageTransactionByIdAsync(int id);
	public Task<DataResult<WastageTransaction>> GetWastageTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentCodeAsync(string code);
}
