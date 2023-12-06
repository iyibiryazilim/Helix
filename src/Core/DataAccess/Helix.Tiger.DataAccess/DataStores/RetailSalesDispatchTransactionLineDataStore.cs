using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesDispatchTransactionLineDataStore : BaseDataStore,IRetailSalesDispatchTransactionLineService
{
	public RetailSalesDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}


	public Task<DataResult<RetailSalesDispatchTransactionLine>> GetRetailSalesDispatchTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesDispatchTransactionLine>().GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
