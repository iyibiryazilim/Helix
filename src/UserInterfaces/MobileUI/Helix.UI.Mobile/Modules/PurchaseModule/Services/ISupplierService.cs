using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;


namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface ISupplierService
	{
		Task<DataResult<IEnumerable<Supplier>>> GetObjects(HttpClient httpClient);
		Task<DataResult<Supplier>> GetObjectById(HttpClient httpClient, int ReferenceId);
		Task<DataResult<Supplier>> GetObjectByCode(HttpClient httpClient, string Code);
	}
}
