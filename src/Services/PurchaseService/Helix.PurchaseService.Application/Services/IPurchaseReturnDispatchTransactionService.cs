using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseReturnDispatchTransactionService
	{ 
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionList(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionById(int id);
		public Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionByCode(string code);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
	}
}
