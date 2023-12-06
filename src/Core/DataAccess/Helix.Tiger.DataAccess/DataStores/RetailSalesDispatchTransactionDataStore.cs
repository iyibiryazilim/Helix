using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

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
