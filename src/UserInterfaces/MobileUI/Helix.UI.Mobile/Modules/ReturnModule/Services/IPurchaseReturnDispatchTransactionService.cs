using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IPurchaseReturnDispatchTransactionService
{
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<PurchaseReturnDispatchTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<PurchaseReturnDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
    Task<DataResult<PurchaseReturnDispatchTransactionInsertDto>> InsertObject(HttpClient httpClient, PurchaseReturnDispatchTransactionInsertDto purchaseReturnDispatchTransactionInsertDto);
}
