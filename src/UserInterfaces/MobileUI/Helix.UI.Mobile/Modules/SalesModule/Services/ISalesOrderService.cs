using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using static Helix.UI.Mobile.Modules.SalesModule.DataStores.SalesOrderDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ISalesOrderService
	{
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjects(HttpClient httpClient, string search, SalesOrderOrderBy orderBy, int page, int pageSize);
		Task<DataResult<SalesOrder>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<SalesOrder>> GetObjectByCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code, string search, SalesOrderOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId, string search, SalesOrderOrderBy orderBy, int page, int pageSize);
        Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentIdAndWarehouseNumber(HttpClient httpClient, int ReferenceId,int WarehouseNumber, string search, SalesOrderOrderBy orderBy, int page, int pageSize);
        Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentIdAndWarehouseNumberAndShipInfo(HttpClient httpClient, int ReferenceId, int WarehouseNumber,int ShipInfoReferenceId, string search, SalesOrderOrderBy orderBy, int page, int pageSize);
      
    }
}
