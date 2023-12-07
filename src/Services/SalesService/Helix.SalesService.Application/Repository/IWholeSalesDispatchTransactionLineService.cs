using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IWholeSalesDispatchTransactionLineService
{
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesAsync();
	public Task<DataResult<WholeSalesDispatchTransactionLine>> GetWholeSalesDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(string code);
}
