using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseOrderService
	{
		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderList(string search, string orderBy, int currentPage, int pageSize);
		public Task<DataResult<PurchaseOrder>> GetPurchaseOrderByCode(string code);
		public Task<DataResult<PurchaseOrder>> GetPurchaseOrderById(int id);

		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentId(string search, string orderBy, int id, int currentPage, int pageSize);

		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentCode(string search, string orderBy, string code, int currentPage, int pageSize);


	}
}
