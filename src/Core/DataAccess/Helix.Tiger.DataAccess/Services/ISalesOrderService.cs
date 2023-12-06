using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface ISalesOrderService
{
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersAsync();
	public Task<DataResult<SalesOrder>> GetSalesOrderByIdAsync(int id);
	public Task<DataResult<SalesOrder>> GetSalesOrderByCode(string code);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentCodeAsync(string code);

}
