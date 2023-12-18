using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ISalesOrderService
	{
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjects(HttpClient httpClient);
		Task<DataResult<SalesOrder>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<SalesOrder>> GetObjectByCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	}
}
