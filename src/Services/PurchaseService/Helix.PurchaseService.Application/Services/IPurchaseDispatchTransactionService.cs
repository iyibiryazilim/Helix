using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseDispatchTransactionService
	{
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionList(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionById(int id);
		public Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionByCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
	}
}
