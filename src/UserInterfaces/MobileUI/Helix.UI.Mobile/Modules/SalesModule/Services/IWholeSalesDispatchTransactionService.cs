using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface IWholeSalesDispatchTransactionService
	{
		Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjects(HttpClient httpClient);
		Task<DataResult<WholeSalesDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<WholeSalesDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	}
}
