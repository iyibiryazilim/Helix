using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface IPurchaseDispatchTransactionLineService
	{//hepsini getiren
		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjects(HttpClient httpClient);

		Task<DataResult<PurchaseDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId);


		//current ıd'ler
		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
		//current kod
		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);

		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId);
		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code);

		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId);

		//Fiche Line Kod
		Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByFicheNo(HttpClient httpClient, string BaseTransactionCode);
	}
}
