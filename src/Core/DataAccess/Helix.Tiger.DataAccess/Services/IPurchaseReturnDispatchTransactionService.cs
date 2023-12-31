﻿using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IPurchaseReturnDispatchTransactionService
	{
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionList();

		public Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionById(int id);
		public Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionByCode(string code);

		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentId(int id);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentCode(string code);



	}
}
