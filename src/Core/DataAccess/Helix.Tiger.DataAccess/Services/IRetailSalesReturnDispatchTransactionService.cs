using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IRetailSalesReturnDispatchTransactionService
{
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsAsync();
	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByIdAsync(int id);
	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(string code);
}
