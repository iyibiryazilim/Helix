using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;
public interface IRetailSalesDispatchTransactionLineService
{
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<RetailSalesDispatchTransactionLine>> GetRetailSalesDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
