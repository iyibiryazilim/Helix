using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface IPurchaseDispatchTransactionService
	{
		Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjects(HttpClient httpClient, string search, SupplierOrderBy orderBy, int page, int pageSize);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="ReferenceId">müşteri/tedarikçi id'si</param>
		/// <returns>müşteri/tedarikçi Id'ye göre fişleri getirir </returns>
		Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="Code">müşteri/tedarikçi kodu</param>
		/// <returns>müşteri/tedarikçi koduna göre fişleri getirir </returns>
		Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="ReferenceId">İlgili fişin Id'si</param>
		/// <returns> İlgili id'ye göre fişi döndrür</returns>
		Task<DataResult<PurchaseDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="Code">İlgili fişin koda</param>
		/// <returns> İlgili koda göre fişi döndrür</returns>

		Task<DataResult<PurchaseDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code);

	}
}
