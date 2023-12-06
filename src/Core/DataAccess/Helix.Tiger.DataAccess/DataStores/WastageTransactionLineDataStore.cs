using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WastageTransactionLineDataStore : BaseDataStore,IWastageTransactionLineService
{
	public WastageTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WastageTransactionLine>> GetWastageTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
