using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ISalesOrderLineService
	{
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjects(HttpClient httpClient, bool includeWaiting, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectByFicheId(HttpClient httpClient, bool includeWaiting, int ReferenceId, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectByFicheCode(HttpClient httpClient, bool includeWaiting, string Code, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code, bool includeWaiting, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId, bool includeWaiting, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code, bool includeWaiting, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId,bool includeWaiting, string search, SalesOrdersLineOrderBy orderBy, int page, int pageSize);
	}
}
