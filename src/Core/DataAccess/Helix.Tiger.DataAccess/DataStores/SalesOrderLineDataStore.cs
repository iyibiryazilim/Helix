using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class SalesOrderLineDataStore : BaseDataStore, ISalesOrderLineService
{
	public SalesOrderLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<SalesOrderLine>> GetSalesOrderLineByCode(string code)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCodeQuery(code));
		return result;
	}

	public Task<DataResult<SalesOrderLine>> GetSalesOrderLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByIdQuery(id));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLinesAsync()
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineQuery());
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentIdQuery(id));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductIdQuery(id));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLinesAsync()
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineQuery());
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentIdQuery(id));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductCodeQuery(code));
		return result;
	}

	public Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductIdQuery(id));
		return result;
	}
}
