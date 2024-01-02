using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;
public interface IWholeSalesReturnDispatchTransactionLineService 
{
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetWholeSalesReturnDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
