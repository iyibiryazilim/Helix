using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IRetailSalesReturnDispatchTransactionLineService
{
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetRetailSalesReturnDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
