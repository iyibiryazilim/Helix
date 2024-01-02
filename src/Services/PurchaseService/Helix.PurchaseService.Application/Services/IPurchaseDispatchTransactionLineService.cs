using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseDispatchTransactionLineService
	{
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineList(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<PurchaseDispatchTransactionLine>> GetPurchaseDispatchTransactionLineById(int id);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize);

	}
}
