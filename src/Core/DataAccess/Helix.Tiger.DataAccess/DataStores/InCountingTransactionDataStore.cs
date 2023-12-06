using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class InCountingTransactionDataStore : BaseDataStore,IInCountingTransactionService
{
	public InCountingTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsAsync()
	{
		var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
