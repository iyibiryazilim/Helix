using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WastageTransactionDataStore : BaseDataStore,IWastageTransactionService
{
	public WastageTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WastageTransaction>> GetWastageTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<WastageTransaction>().GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<WastageTransaction>> GetWastageTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransaction>().GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsAsync()
	{
		var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
