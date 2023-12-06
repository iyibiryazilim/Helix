using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IWholeSalesReturnDispatchTransactionService
{
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsAsync();
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByIdAsync(int id);
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(string code);
}
