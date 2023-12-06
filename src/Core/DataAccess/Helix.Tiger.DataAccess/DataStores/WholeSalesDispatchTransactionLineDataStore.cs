using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesDispatchTransactionLineDataStore : BaseDataStore,IWholeSalesDispatchTransactionLineService
{
	public WholeSalesDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WholeSalesDispatchTransactionLine>> GetWholeSalesDispatchTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
