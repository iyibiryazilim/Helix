using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IPurchaseReturnDispatchTransactionLineService
{
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjects(HttpClient httpClient);

	Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheNo(HttpClient httpClient, string BaseTransactionCode);

}
