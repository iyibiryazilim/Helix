using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;


namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface IPurchaseOrderLineService
	{
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrders(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<PurchaseOrderLine>> GetWaitingOrderById(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize);
		Task<DataResult<PurchaseOrderLine>> GetWaitingOrderByCode(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, string Code, int page, int pageSize);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentId(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentCode(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, string Code, int page, int pageSize);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductId(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize);
		Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductCode(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, string Code, int page, int pageSize);
	}
}
