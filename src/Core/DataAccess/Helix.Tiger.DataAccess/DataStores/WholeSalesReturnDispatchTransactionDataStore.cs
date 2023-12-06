using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesReturnDispatchTransactionDataStore : BaseDataStore,IWholeSalesReturnDispatchTransactionService
{
	public WholeSalesReturnDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransaction>().GetObjectAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransaction>().GetObjectAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsAsync()
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransaction>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransaction>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransaction>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
