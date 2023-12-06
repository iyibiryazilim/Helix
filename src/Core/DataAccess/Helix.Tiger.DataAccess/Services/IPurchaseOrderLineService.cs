using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IPurchaseOrderLineService
	{
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLine();
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLine();
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCode(string code);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineById(int id);

		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentId(int id);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentId(int id);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentCode(string code);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentCode(string code);

		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductId(int id);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductId(int id);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductCode(string code);
		public Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductCode(string code);







	}
}
