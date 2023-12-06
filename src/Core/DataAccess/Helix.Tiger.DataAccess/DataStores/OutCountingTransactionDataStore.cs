using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

internal class OutCountingTransactionDataStore : BaseDataStore,IOutCountingTransactionService
{
	public OutCountingTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsAsync()
	{
		var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
