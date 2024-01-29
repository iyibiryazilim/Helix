using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface IRetailSalesDispatchTransactionService
{
	Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<RetailSalesDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<RetailSalesDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient,string Code);
	Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient,int ReferenceId);
	Task<DataResult<RetailSalesDispatchTransaction>> InsertObject(HttpClient httpClient, RetailSalesDispatchTransactionDto retailSalesDispatchTransactionDto);
}
