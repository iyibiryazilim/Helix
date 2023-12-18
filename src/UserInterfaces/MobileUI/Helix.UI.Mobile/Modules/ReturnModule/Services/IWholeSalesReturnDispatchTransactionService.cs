using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IWholeSalesReturnDispatchTransactionService
{
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
	Task<DataResult<WholeSalesReturnDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<WholeSalesReturnDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code);
	//Task<DataResult<WholeSalesReturnDispatchTransaction>> InsertAsync(HttpClient httpClient, WholeSalesReturnTransactionInsertDto dto);
}
