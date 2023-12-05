﻿using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseReturnDispatchTransactionDataStore : BaseDataStore, IPurchaseReturnDispatchTransactionService
	{
		public PurchaseReturnDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionByCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
			return result;
		}

		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionById(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionList()
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionList());
			return result;
		}
	}
}
