using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesDispatchTransactionDataStore : BaseDataStore,IWholeSalesDispatchTransactionService
{
	public WholeSalesDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsAsync()
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
