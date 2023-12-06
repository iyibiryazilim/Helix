using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IPurchaseDispatchTransactionService
	{
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionList();
		public Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionById(int id);
		public Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionByCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentId(int id);
	}
}
