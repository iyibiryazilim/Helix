using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IWholeSalesDispatchTransactionService
{
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsAsync();
	public Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByIdAsync(int id);
	public Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentCodeAsync(string code);
}
