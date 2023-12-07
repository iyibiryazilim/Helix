using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesReturnDispatchTransactionDataStore : BaseDataStore,IRetailSalesReturnDispatchTransactionService
{
	public RetailSalesReturnDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransaction>().GetObjectAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransaction>().GetObjectAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsAsync()
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransaction>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransaction>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransaction>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
