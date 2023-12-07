using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Repository;

public class RetailSalesDispatchTransactionDataStore : BaseDataStore, IRetailSalesDispatchTransactionService
{
    public RetailSalesDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByCode(string code)
    {
		var result = new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

    public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByIdAsync(int id)
    {
		var result = new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

    public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsAsync()
    {
		var result = new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

    public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentCodeAsync(string code)
    {
		var result = new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

    public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentIdAsync(int id)
    {
		var result = new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
