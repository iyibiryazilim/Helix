using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ISalesOrderLineService
	{
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjects(HttpClient httpClient, bool includeWaiting);
		Task<DataResult<SalesOrderLine>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<SalesOrderLine>> GetObjectByCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code, bool includeWaiting);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId, bool includeWaiting);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code, bool includeWaiting);
		Task<DataResult<IEnumerable<SalesOrderLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId,bool includeWaiting);
	}
}
