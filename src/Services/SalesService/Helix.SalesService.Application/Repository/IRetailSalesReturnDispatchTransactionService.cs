using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;
public interface IRetailSalesReturnDispatchTransactionService
{
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByIdAsync(int id);
	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
