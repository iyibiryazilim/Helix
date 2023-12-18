using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface IRetailSalesDispatchTransactionLineService
{
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<RetailSalesDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId);
}
