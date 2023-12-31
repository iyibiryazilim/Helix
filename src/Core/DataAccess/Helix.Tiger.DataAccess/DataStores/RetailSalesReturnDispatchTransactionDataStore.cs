﻿using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
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
