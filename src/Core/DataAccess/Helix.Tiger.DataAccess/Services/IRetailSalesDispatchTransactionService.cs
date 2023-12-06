using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IRetailSalesDispatchTransactionService
{
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsAsync();
	public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByIdAsync(int id);
	public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentCodeAsync(string code);
}
