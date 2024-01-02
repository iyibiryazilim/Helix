using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IWholeSalesReturnDispatchTransactionService
{
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByIdAsync(int id);
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
