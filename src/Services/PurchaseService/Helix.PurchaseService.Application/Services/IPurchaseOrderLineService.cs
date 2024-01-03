using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseOrderLineService
	{
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLine(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLine(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByFicheId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByFicheId(string search, string orderBy, int id, int page, int pageSize);


	}
}
