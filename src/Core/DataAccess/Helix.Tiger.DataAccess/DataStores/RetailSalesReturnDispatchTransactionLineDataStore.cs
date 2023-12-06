using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesReturnDispatchTransactionLineDataStore : BaseDataStore,IRetailSalesReturnDispatchTransactionLineService
{
	public RetailSalesReturnDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetRetailSalesReturnDispatchTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
