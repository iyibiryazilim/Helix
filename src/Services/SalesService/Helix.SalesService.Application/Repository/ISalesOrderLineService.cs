using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface ISalesOrderLineService
{
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLinesAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<SalesOrderLine>> GetSalesOrderLineByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<SalesOrderLine>> GetWaitingSalesOrderLineByFicheIdAsync(int id, string search, string orderBy, int page, int pageSize);

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLineFicheByCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLineFicheByCodeAsync(string code, string search, string orderBy, int page, int pageSize);

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductCodeAsync(string code, string search, string orderBy, int page, int pageSize);
}
