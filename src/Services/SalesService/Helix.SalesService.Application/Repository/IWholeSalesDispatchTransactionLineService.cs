using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IWholeSalesDispatchTransactionLineService
{
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<WholeSalesDispatchTransactionLine>> GetWholeSalesDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
