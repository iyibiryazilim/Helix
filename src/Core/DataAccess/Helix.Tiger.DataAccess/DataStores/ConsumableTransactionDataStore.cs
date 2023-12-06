using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class ConsumableTransactionDataStore : BaseDataStore,IConsumableTransactionService
{
	public ConsumableTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<ConsumableTransaction>().GetObjectAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransaction>().GetObjectAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsAsync()
	{
		var result = new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
