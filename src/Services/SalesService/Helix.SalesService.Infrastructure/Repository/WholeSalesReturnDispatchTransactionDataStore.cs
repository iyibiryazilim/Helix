using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
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
