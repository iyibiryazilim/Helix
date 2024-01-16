using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface IPurchaseOrderService
	{
		Task<DataResult<IEnumerable<PurchaseOrder>>> GetObjects(HttpClient httpClient, string search, PurchaseOrderOrderBy orderBy, int page, int pageSize);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="ReferenceId">müşteri/tedarikçi id'si</param>
		/// <returns>müşteri/tedarikçi Id'ye göre fişleri getirir </returns>
		Task<DataResult<IEnumerable<PurchaseOrder>>> GetObjectsByCurrentId(HttpClient httpClient, string search, PurchaseOrderOrderBy orderBy, int id, int page, int pageSize);

        Task<DataResult<IEnumerable<PurchaseOrder>>> GetObjectsByCurrentIdAndWarehouseNumber(HttpClient httpClient, string search, PurchaseOrderOrderBy orderBy, int id,int WarehouseNumber, int page, int pageSize);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="Code">müşteri/tedarikçi kodu</param>
        /// <returns>müşteri/tedarikçi koduna göre fişleri getirir </returns>
        Task<DataResult<IEnumerable<PurchaseOrder>>> GetObjectsByCurrentCode(HttpClient httpClient, string search, PurchaseOrderOrderBy orderBy, string code, int page, int pageSize);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="ReferenceId">İlgili fişin Id'si</param>
		/// <returns> İlgili id'ye göre fişi döndrür</returns>
		Task<DataResult<PurchaseOrder>> GetObjectById(HttpClient httpClient, int ReferenceId);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="Code">İlgili fişin koda</param>
		/// <returns> İlgili koda göre fişi döndrür</returns>

		Task<DataResult<PurchaseOrder>> GetObjectByCode(HttpClient httpClient, string Code);

	}
}
