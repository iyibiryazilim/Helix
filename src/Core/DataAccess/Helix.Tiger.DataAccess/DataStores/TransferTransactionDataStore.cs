using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class TransferTransactionDataStore : BaseDataStore,ITransferTransactionService
{
	public TransferTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<TransferTransaction>> GetTransferTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<TransferTransaction>().GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<TransferTransaction>> GetTransferTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransaction>().GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsAsync()
	{
		var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
