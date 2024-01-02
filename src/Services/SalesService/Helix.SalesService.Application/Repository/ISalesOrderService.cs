using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;
public interface ISalesOrderService
{
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersAsync(string search, string orderBy, int page, int pageSize);
	public Task<DataResult<SalesOrder>> GetSalesOrderByIdAsync(int id);
	public Task<DataResult<SalesOrder>> GetSalesOrderByCode(string code);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAsync(int id, string search, string orderBy, int page, int pageSize);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentCodeAsync(string code, string search, string orderBy, int page, int pageSize);

}
