using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IWholeSalesReturnDispatchTransactionService
{
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsAsync();
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByIdAsync(int id);
	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(string code);
}
