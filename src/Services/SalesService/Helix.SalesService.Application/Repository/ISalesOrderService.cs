using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;
public interface ISalesOrderService
{
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersAsync();
	public Task<DataResult<SalesOrder>> GetSalesOrderByIdAsync(int id);
	public Task<DataResult<SalesOrder>> GetSalesOrderByCode(string code);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentCodeAsync(string code);

}
