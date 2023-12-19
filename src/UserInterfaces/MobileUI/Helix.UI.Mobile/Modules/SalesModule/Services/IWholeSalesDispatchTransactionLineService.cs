using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface IWholeSalesDispatchTransactionLineService
	{
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjects(HttpClient httpClient);
		Task<DataResult<WholeSalesDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string Code);
		Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId);
	}
}
