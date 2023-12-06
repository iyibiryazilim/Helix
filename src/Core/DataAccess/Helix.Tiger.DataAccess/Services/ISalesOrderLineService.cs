using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface ISalesOrderLineService
{
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLinesAsync();
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLinesAsync();
	public Task<DataResult<SalesOrderLine>> GetSalesOrderLineByIdAsync(int id);
	public Task<DataResult<SalesOrderLine>> GetSalesOrderLineByCode(string code);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductCodeAsync(string code);
}
