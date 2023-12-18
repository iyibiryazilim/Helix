using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;


namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface IPurchaseOrderLineService
	{
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrders(HttpClient httpClient, bool IsWaiting = true);
		Task<DataResult<PurchaseOrderLine>> GetWaitingOrderById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<PurchaseOrderLine>> GetWaitingOrderByCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentId(HttpClient httpClient, int currentReferenceId, bool IsWaiting = true);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentCode(HttpClient httpClient, string currentCode, bool IsWaiting = true);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductId(HttpClient httpClient, int productReferenceId, bool IsWaiting = true);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductCode(HttpClient httpClient, string productCode, bool IsWaiting = true);
	}
}
