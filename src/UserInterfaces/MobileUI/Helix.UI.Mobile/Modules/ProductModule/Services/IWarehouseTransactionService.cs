using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.Services
{
    public interface IWarehouseTransactionService
    {
		Task<DataResult<IEnumerable<WarehouseTransaction>>> GetWarehouseTransactions(HttpClient httpClient,int number, string search, WarehouseTransactionOrderBy orderBy, int page, int pageSiz);
	}
}
