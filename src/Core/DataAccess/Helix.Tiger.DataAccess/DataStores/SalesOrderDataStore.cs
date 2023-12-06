using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class SalesOrderDataStore : BaseDataStore, ISalesOrderService
{
	public SalesOrderDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<SalesOrder>> GetSalesOrderByIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrder>().GetObjectAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByIdQuery(id));
		return result;
	}

	public Task<DataResult<SalesOrder>> GetSalesOrderByCode(string code)
	{
		var result = new SqlQueryHelper<SalesOrder>().GetObjectAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersAsync()
	{
		var result = new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderQuery());
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCurrentCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCurrentIdQuery(id));
		return result;
	}
}
